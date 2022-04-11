using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Teachers
    {
        public bool AddTeacher(TeacherDetails teacherDetails , bool append)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Teacher.txt");
                using (StreamWriter streamWriter = new StreamWriter(fileInfo.FullName, append))
                {
                    streamWriter.WriteLine($"{teacherDetails.Id}\t{teacherDetails.Name}\t{teacherDetails.Class}\t {teacherDetails.Section}");
                    streamWriter.Flush();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }


        }

        public bool RemoveTeacher(int id)
        {
            List<TeacherDetails> teachers = new List<TeacherDetails>();
            try
            {
                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Teacher.txt");
                string[] lines = File.ReadAllLines(fileInfo.FullName);

                foreach (var line in lines)
                {
                    TeacherDetails teacher = new TeacherDetails();
                    string[] values = line.Split('\t');
                    teacher.Id = Convert.ToInt32(values[0]);
                    teacher.Name = values[1];
                    teacher.Class = Convert.ToInt32(values[2]);
                    teacher.Section = values[3];
                    teachers.Add(teacher);
                }
                if (teachers != null)
                {

                    var teachToDelete = teachers.Where(x => x.Id == id).FirstOrDefault();
                    teachers.Remove(teachToDelete);
                    fileInfo.Delete();
                    foreach (var teach in teachers)
                    {
                        AddTeacher(teach, true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void PrintAllTeachers()
        {
            try
            {

                string path = Environment.CurrentDirectory;
                FileInfo fileInfo = new FileInfo(path + "\\Teacher.txt");

                string[] lines = File.ReadAllLines(fileInfo.FullName);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
