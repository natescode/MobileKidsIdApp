﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class UserIdentity : BusinessBase<UserIdentity>
    {
        public static readonly PropertyInfo<string> ProviderNameProperty = RegisterProperty<string>(c => c.ProviderName);
        public string ProviderName
        {
            get { return GetProperty(ProviderNameProperty); }
            set { SetProperty(ProviderNameProperty, value); }
        }

        public static readonly PropertyInfo<string> UserIdFromProviderProperty = RegisterProperty<string>(c => c.UserIdFromProvider);
        public string UserIdFromProvider
        {
            get { return GetProperty(UserIdFromProviderProperty); }
            set { SetProperty(UserIdFromProviderProperty, value); }
        }
    }
}