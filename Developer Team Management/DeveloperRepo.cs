using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Team_Management
{
     
    public class DeveloperRepo
    {

        
        private List<Developer> _listOfDev = new List<Developer>();

        //Create
        public void AddContentToList(Developer devcontent)
        {
            _listOfDev.Add(devcontent);
        }

        //Read
        public List<Developer> GetDevContent()
        {
            return _listOfDev;
        }

        //Update

        public bool updateExistingContent(int originalUniqueId, Developer newInfo)
        {
            //Find the content
            Developer oldInfo = GetContentById(originalUniqueId);
            
            //Update the content
            if(oldInfo != null)
            {
                oldInfo.UniqueId = newInfo.UniqueId;
                oldInfo.FirstName = newInfo.FirstName;
                oldInfo.LastName = newInfo.LastName;
                oldInfo.PhoneNumber = newInfo.PhoneNumber;
                oldInfo.TypeOfDev = newInfo.TypeOfDev;
                oldInfo.IsPluralSight = newInfo.IsPluralSight;

                return true;
            }
            else 
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDevContent(int uniqueId)
        {
            Developer devcontent = GetContentById(uniqueId);

            if (devcontent == null)
            {
                return false;
            }

            int initialCount = _listOfDev.Count;
            _listOfDev.Remove(devcontent);

            if(initialCount > _listOfDev.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public Developer GetContentById(int uniqueId)
        {
            foreach (Developer devcontent in _listOfDev)
            {
                if (devcontent.UniqueId == uniqueId)
                {
                    return devcontent;
                }
            }
            return null;



        }
    }

    }



