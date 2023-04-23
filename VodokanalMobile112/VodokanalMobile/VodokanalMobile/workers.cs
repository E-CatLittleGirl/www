using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace VodokanalMobile
{
    [Table("workers")]
    public class workers : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("id_workers")]
        public int id_workers { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int tub_name { get; set; }
        public string phone { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
