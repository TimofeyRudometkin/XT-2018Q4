using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Task7.Users.DAL.TextFiles
{
    public class UserTextFilesDao : IUserDao
    {
        private static StringBuilder _stringBuilder = new StringBuilder();
        private static StringBuilder _pathOfTextFiles = new StringBuilder(@"C:\DirectoryWithTextFiles(Task7)");
        private static StringBuilder _nameOfTextFileWithUsers = new StringBuilder("DateOfUsers.txt");
        string _contentOfFile1;
        string[] _contentOfFile;
        public void Add(User user)
        {
            try
            {
                int _maxIndex = 0;
                if (!File.Exists(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    if (!Directory.Exists(_pathOfTextFiles.ToString()))
                    {
                        Directory.CreateDirectory(_pathOfTextFiles.ToString());
                    }
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), true))
                    {
                        ;
                    }
                }
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 4)
                        {
                            _maxIndex = int.Parse(_contentOfFile[i]) > _maxIndex
                                      ? int.Parse(_contentOfFile[i])
                                      : _maxIndex;
                        }
                        _maxIndex++;
                    }
                }
                using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), true))
                {
                    if (_maxIndex != 0)
                    {
                        streamWriterTextFiles.Write($" {_maxIndex} {user.Name} {user.DateOfBirthday.ToShortDateString()} {user.Age}");
                    }
                    else
                    {
                        streamWriterTextFiles.Write($"{_maxIndex} {user.Name} {user.DateOfBirthday.ToShortDateString()} {user.Age}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                //throw new Exception("Can't add user to text file.");
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                bool fileIsNotEmpty = false;
                int _indexOfTheDeletedUser = Id;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split();
                    for (int i = 0; i < _contentOfFile.Length; i += 4)
                    {
                        if(int.Parse(_contentOfFile[i]) == _indexOfTheDeletedUser)
                        {
                            _contentOfFile[i] = "";
                            _contentOfFile[i+1] = "";
                            _contentOfFile[i+2] = "";
                            _contentOfFile[i+3] = "";

                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length; j += 4)
                                {
                                    if (fileIsNotEmpty && _contentOfFile[j] != "" && _contentOfFile[j + 1] != "" && _contentOfFile[j + 2] != "" && _contentOfFile[j + 3] != "")
                                    {
                                        streamWriterTextFiles.Write($" {_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j + 2]} {_contentOfFile[j + 3]}");
                                    }
                                    else if (_contentOfFile[j] != "" && _contentOfFile[j + 1] != "" && _contentOfFile[j + 2] != "" && _contentOfFile[j + 3] != "")
                                    {
                                        streamWriterTextFiles.Write($"{_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j + 2]} {_contentOfFile[j + 3]}");
                                        fileIsNotEmpty = true;
                                    }
                                }
                            }

                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't delete user from text file.");
            }
        }
        public bool Update(User user)
        {
            try
            {
                bool fileIsNotEmpty = false;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split();
                    for (int i = 0; i < _contentOfFile.Length; i += 4)
                    {
                        if (int.Parse(_contentOfFile[i]) == user.Id)
                        {
                            _contentOfFile[i + 1] = user.Name.ToString();
                            _contentOfFile[i + 2] = user.DateOfBirthday.ToShortDateString();
                            _contentOfFile[i + 3] = user.Age.ToString();

                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length; j += 4)
                                {
                                    if(fileIsNotEmpty && _contentOfFile[j] != "" && _contentOfFile[j + 1] != "" && _contentOfFile[j + 2] != "" && _contentOfFile[j + 3] != "")
                                    {
                                        streamWriterTextFiles.Write($" {_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j + 2]} {_contentOfFile[j + 3]}");
                                    }
                                    else if(_contentOfFile[j] != "" && _contentOfFile[j + 1] != "" && _contentOfFile[j + 2] != "" && _contentOfFile[j + 3] != "")
                                    {
                                        streamWriterTextFiles.Write($"{_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j + 2]} {_contentOfFile[j + 3]}");
                                        fileIsNotEmpty = true;
                                    }
                                }
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't update user from text file.");
            }

        }
        public User GetById(int Id)
        {
            try
            {
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 4)
                        {
                            if (int.Parse(_contentOfFile[i]) == Id)
                            {
                                User user = new User();
                                user.Id = int.Parse(_contentOfFile[i]);
                                user.Name = _contentOfFile[i + 1];
                                user.DateOfBirthday = DateTime.Parse(_contentOfFile[i + 2]);
                                user.Age = int.Parse(_contentOfFile[i + 3]);
                                return user;
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't get user from text file.");
            }
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                Dictionary<int, User> _repoUsers = new Dictionary<int, User>();
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i<_contentOfFile.Length; i += 4)
                        {
                            User user = new User();
                            user.Id = int.Parse(_contentOfFile[i]);
                            user.Name = _contentOfFile[i + 1];
                            user.DateOfBirthday = DateTime.Parse(_contentOfFile[i + 2]);
                            user.Age = int.Parse(_contentOfFile[i + 3]);
                            _repoUsers.Add(user.Id, user);
                        }
                        return _repoUsers.Values;
                    }
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't get all users from text file.");
            }
        }
    }
}
