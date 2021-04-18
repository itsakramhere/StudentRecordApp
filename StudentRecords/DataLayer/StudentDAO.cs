using StudentRecords.IDAO;
using StudentRecords.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecords.DataLayer
{
    
    public class StudentDAO:IDisposable,IDaoLayer<StudentViewModel>
    {
        public void Dispose() { }
        DataBase<StudentViewModel> db = new DataBase<StudentViewModel>();
        public bool Add(StudentViewModel x)
        {
            try
            {
                var items = DataBase<StudentViewModel>.db;
                bool found = false;

                foreach (var item in items)
                {
                    var modelItem = (StudentViewModel)item;
                    if (modelItem.RollNumber == x.RollNumber)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    int success = DataBase<StudentViewModel>.db.Add(x);
                    if (success >= 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return false;
        }

        public ArrayList Index()
        {
            try
            {
                return DataBase<StudentViewModel>.db;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return null;

        }

        public bool Edit(StudentViewModel x, int id)
        {
            try
            {
                var items = DataBase<StudentViewModel>.db;
                int count = 0;
                foreach (var item in items)
                {
                    var modelItem = (StudentViewModel)item;

                    if (modelItem.RollNumber == id)
                    {

                        items.Remove(item);
                        items.Insert(count, x);
                        return true;
                    }
                    count++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return false;
        }

        public StudentViewModel Edit(int id)
        {
            try
            {
                var items = DataBase<StudentViewModel>.db;

                foreach (var item in items)
                {
                    var modelItem = (StudentViewModel)item;
                    if (modelItem.RollNumber == id)
                    {
                        return modelItem;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return null;

        }

        public bool Delete(int id)
        {
            try
            {
                var items = DataBase<StudentViewModel>.db;

                foreach (var item in items)
                {
                    var modelItem = (StudentViewModel)item;
                    if (modelItem.RollNumber == id)
                    {
                        items.Remove(item);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return false;
        }
        public ArrayList Search(int searchField,string query)
        {
            ArrayList models = new ArrayList();
            try
            {
                var items = DataBase<StudentViewModel>.db;

                foreach (var item in items)
                {
                    var modelItem = (StudentViewModel)item;
                    bool found = false;
                    switch (searchField)
                    {
                        case 1:
                            if (modelItem.RollNumber == Convert.ToInt32(query))
                            {
                                found = true;
                            }
                            break;
                        case 2:
                            if (modelItem.Name.ToLower() == query.ToLower())
                            {
                                found = true;
                            }
                            break;
                        case 3:
                            if (modelItem.Age == Convert.ToInt32(query))
                            {
                                found = true;
                            }
                            break;
                        case 4:
                            if (modelItem.Gender.ToLower() == query.ToLower())
                            {
                                found = true;
                            }
                            break;



                    }
                    if (found)
                    {
                        models.Add(modelItem);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.ToString() + ex.Source + ex.StackTrace + ex.TargetSite?.ToString() + ex.HelpLink);
            }
            return models;

        }

        

    }
}