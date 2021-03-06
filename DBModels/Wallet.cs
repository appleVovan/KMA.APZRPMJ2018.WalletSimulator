﻿using System;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

namespace KMA.APZRPMJ2018.WalletSimulator.DBModels
{
    [DataContract(IsReference = true)]
    public class Wallet
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _title;
        [DataMember]
        private long _totalIncome;
        [DataMember]
        private long _totalOutcome;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public long TotalIncome
        {
            get { return _totalIncome; }
            private set { _totalIncome = value; }
        }
        public long TotalOutcome
        {
            get { return _totalOutcome; }
            private set { _totalOutcome = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        #endregion

        #region Constructor
        public Wallet(string title, User user) : this()
        {
            _guid = Guid.NewGuid();
            _title = title;
            _totalIncome = 0;
            _totalOutcome = 0;
            _userGuid = user.Guid;
            _user = user;
            user.Wallets.Add(this);
        }
        private Wallet()
        {
        }
        #endregion
        public override string ToString()
        {
            return Title;
        }

        #region EntityFrameworkConfiguration
        public class WalletEntityConfiguration : EntityTypeConfiguration<Wallet>
        {
            public WalletEntityConfiguration()
            {
                ToTable("Wallet");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                Property(s => s.TotalIncome)
                    .HasColumnName("TotalIncome")
                    .IsRequired();
                Property(s => s.TotalOutcome)
                    .HasColumnName("TotalOutcome")
                    .IsRequired();
            }
        }
        #endregion

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}
