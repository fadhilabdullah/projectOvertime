﻿using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public interface ISubmitedRepository
    {
        List<Submited> Get();
        List<Submited> GetSearch(string values);
        Submited Get(int id);
        bool Insert(SubmitedVM submitedVM);
        bool Update(int id, SubmitedVM submitedVM);
        bool Delete(int id);
    }
}
