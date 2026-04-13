using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Async;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSCommandantRepository : MSRepository, ICommandantRepository
    {
        public MSCommandantRepository(string connectionString) : base(connectionString) { }

        public async Task<bool> AddPayment(Payment payment)
        {
            try
            {
                using (var db = new DataConnection(options))
                {

                    await db.InsertAsync(payment);
                    return true;
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> ChangePayment(int paymentId, decimal amount, DateTime date)
        {
            try
            {
                using (var db = new DataConnection(options))
                {

                    var payment = await db.GetTable<Payment>().FirstOrDefaultAsync(p => p.PaymentID == paymentId);
                    if (payment != null)
                    {
                        payment.PaidAmount = amount;
                        payment.LastPaymentDate = date;
                        await db.UpdateAsync(payment);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> EvictStudent(int studentId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {

                    var student = await db.GetTable<Student>().FirstOrDefaultAsync(s => s.StudentID == studentId);

                    if (student != null)
                    {
                        student.RoomID = null;
                        await db.UpdateAsync(student);
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> RemoveBenefitFromStudent(int benefitId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var exists = await db.GetTable<StudentBenefit>().AnyAsync(sb => sb.StudentBenefitID == benefitId);

                    if (!exists) { return false; }
                    await db.GetTable<StudentBenefit>().Where(sb => sb.StudentBenefitID == benefitId).DeleteAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveInventoryFromRoom(int itemId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {

                    var inventory = await db.GetTable<Inventory>().FirstOrDefaultAsync(i => i.ItemID == itemId);

                    if (inventory != null)
                    {
                        inventory.RoomID = null;
                        await db.UpdateAsync(inventory);
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> RemovePayment(int paymentId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var exists = await db.GetTable<Payment>().AnyAsync(p => p.PaymentID == paymentId);

                    if (!exists) { return false; }
                    await db.GetTable<Payment>().Where(p => p.PaymentID == paymentId).DeleteAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SetBenefitForStudent(StudentBenefit studentBenefit)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var studentExists = await db.GetTable<Student>().AnyAsync(s => s.StudentID == studentBenefit.StudentID);
                    if (!studentExists) return false;

                    var benefitExists = await db.GetTable<BenefitType>().AnyAsync(b => b.BenefitID == studentBenefit.BenefitID);
                    if (!benefitExists) return false;

                    await db.InsertAsync(studentBenefit);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SetInventoryForRoom(int itemId, int roomId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var room = await db.GetTable<Room>().AnyAsync(r => r.RoomID == roomId);
                    if (!room) { return false; }
                    var inventory = await db.GetTable<Inventory>().FirstOrDefaultAsync(i => i.ItemID == itemId);

                    if (inventory != null)
                    {
                        inventory.RoomID = roomId;
                        await db.UpdateAsync(inventory);
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> SetRoomForStudent(int studentId, int roomId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var room = await db.GetTable<Room>().LoadWith(r => r.Students).FirstOrDefaultAsync(r => r.RoomID == roomId);
                    if (room == null || room.Students.Count >= room.Capacity) { return false; }
                    var student = await db.GetTable<Student>().FirstOrDefaultAsync(s => s.StudentID == studentId);

                    if (student != null)
                    {
                        student.RoomID = roomId;
                        await db.UpdateAsync(student);
                        return true;
                    }
                    else
                    { return false; }
                }
            }
            catch (Exception ex)
            { return false; }
        }
    }
}
