﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace VodokanalMobile
{
    public class VodokanalAsyncRepository
    {
        private SQLiteConnection database;
        private static object collisionlock = new object();
        public ObservableCollection<workers> workers { get; set; }

        public ObservableCollection<zayavky> zayavky { get; set; }

        

        public VodokanalAsyncRepository()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<zayavky>();
            database.CreateTable<workers>();
            //database.CreateTable<action_work>();
            //database.CreateTable<action_zayavka>();
            //database.CreateTable<Status>();
            this.workers = new ObservableCollection<workers>(database.Table<workers>());
            this.zayavky = new ObservableCollection<zayavky>(database.Table<zayavky>());

        }

        //public  Task CreateTable()
        //{
            //database.CreateTable<zayavky>();
            //database.CreateTable<workers>();
            //database.CreateTable<action_work>();
            //database.CreateTable<action_zayavka>();
            //database.CreateTable<Status>();
            //this.workers = new ObservableCollection<workers>(database.Table<workers>);

        //}
        public List<zayavky> GetZayavky()
        {
            //return database.Table<zayavky>.();
            lock (collisionlock)
            {
                return database.Table<zayavky>().ToList();
            }
        }
        //public async Task<List<workers>> GetItemsWorkersAsync()
        //{
        //    return await database.Table<workers>().ToListAsync();
        //}
        //public async Task<List<action_work>> GetItemsActionWorkAsync()
        //{
        //    return await database.Table<action_work>().ToListAsync();
        //}
        public workers GetItem(string login)
        {
            lock(collisionlock)
            {
                return database.Table<workers>().FirstOrDefault(x => x.login == login);
            }
        }
        //public async Task<List<action_zayavka>> GetItemsActionZayavkaAsync()
        //{
        //    return await database.Table<action_zayavka>().ToListAsync();
        //}
        //public async Task<List<Status>> GetItemsStatusAsync()
        //{
        //    return await database.Table<Status>().ToListAsync();
        //}

        public zayavky GetIdZayavky(int id)
        {
            lock (collisionlock)
            {
                //return database.Table<zayavky>().Where(i => i.id_zayavky == id).FirstOrDefault();
                return database.Table<zayavky>().FirstOrDefault(i => i.id_zayavky == id);
            }
        }
        //public async Task<workers> GetItemWorkersAsync(int id)
        //{
        //    return await database.GetAsync<workers>(id);
        //}
        //public async Task<action_zayavka> GetItemActionZayavkaAsync(int id)
        //{
        //    return await database.GetAsync<action_zayavka>(id);
        //}
        //public async Task<action_work> GetItemActionWorkAsync(int id)
        //{
        //    return await database.GetAsync<action_work>(id);
        //}
        //public async Task<Status> GetItemStatusAsync(int id)
        //{
        //    return await database.GetAsync<Status>(id);
        //}

        //public async Task<int> DeleteItemZayavkyAsync(zayavky item)
        //{
        //    return await database.DeleteAsync(item);
        //}
        //public async Task<int> DeleteItemWorkersAsync(workers item)
        //{
        //    return await database.DeleteAsync(item);
        //}
        //public async Task<int> DeleteItemActionZayavkaAsync(action_zayavka item)
        //{
        //    return await database.DeleteAsync(item);
        //}
        //public async Task<int> DeleteItemActionWorkAsync(action_work item)
        //{
        //    return await database.DeleteAsync(item);
        //}
        //public async Task<int> DeleteItemStatusAsync(Status item)
        //{
        //    return await database.DeleteAsync(item);
        //}
        public async Task<int> SaveItemZayavky(zayavky z)
        {
            if(z.id_zayavky != 0)
            {
                database.Update(z);
                return z.id_zayavky;
            }
            else
            {
                return database.Insert(z);
            }
        }

        //public async Task<int> SaveItemWorkersAsync(workers item)
        //{
        //    if(item.id_workers != 0)
        //    {
        //        await database.UpdateAsync(item);
        //        return item.id_workers;
        //    }
        //    else
        //    {
        //        return await database.InsertAsync(item);
        //    }
        //}
        //public async Task<int> SaveItemActionWorkAsync(action_work item)
        //{
        //    if(item.id_action_work!= 0)
        //    {
        //        await database.UpdateAsync(item);
        //        return item.id_action_work;
        //    }
        //    else
        //    {
        //        return await database.InsertAsync(item);
        //    }
        //}
        //public async Task<int> SaveItemActionZayavkaAsync(action_zayavka item)
        //{
        //    if(item.id_action_zayavka != 0)
        //    {
        //        await database.UpdateAsync(item);
        //        return item.id_action_zayavka;
        //    }
        //    else
        //    {
        //        return await database.InsertAsync(item);
        //    }
        //}
        //public async Task<int> SaveItemStatusAsync(Status item)
        //{
        //    if (item.Id_status!= 0)
        //    {
        //        await database.UpdateAsync(item);
        //        return item.Id_status;
        //    }
        //    else
        //    {
        //        return await database.InsertAsync(item);
        //    }
        //}

    }
}
