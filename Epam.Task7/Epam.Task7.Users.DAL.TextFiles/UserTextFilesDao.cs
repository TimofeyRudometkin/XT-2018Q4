using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Task7.Users.DAL.TextFiles
{
    public class UserTextFilesDao : IUserDao, IAwardDao
    {
        private static StringBuilder _stringBuilder = new StringBuilder();
        private static StringBuilder _pathOfTextFiles = new StringBuilder(@"C:\DirectoryWithTextFiles(Task7)");
        private static StringBuilder _nameOfTextFileWithUsers = new StringBuilder("DateOfUsers.txt");
        private static StringBuilder _nameOfTextFileWithAwards = new StringBuilder("DateOfAwards.txt");
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

        public void Add(Award award)
        {
            try
            {
                int _maxIndex = 0;
                if (!File.Exists(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    if (!Directory.Exists(_pathOfTextFiles.ToString()))
                    {
                        Directory.CreateDirectory(_pathOfTextFiles.ToString());
                    }
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString()), true))
                    {
                        ;
                    }
                }
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 2)
                        {
                            _maxIndex = int.Parse(_contentOfFile[i]) > _maxIndex
                                      ? int.Parse(_contentOfFile[i])
                                      : _maxIndex;
                        }
                        _maxIndex++;
                    }
                }
                using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString()), true))
                {
                    if (_maxIndex != 0)
                    {
                        streamWriterTextFiles.Write($" {_maxIndex} {award.Title}");
                    }
                    else
                    {
                        streamWriterTextFiles.Write($"{_maxIndex} {award.Title}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't add award to text file.");
            }
        }
        public bool DeleteAward(int Id)
        {
            try
            {
                bool fileIsNotEmpty = false;
                int _indexOfTheDeletedUser = Id;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split();
                    for (int i = 0; i < _contentOfFile.Length; i += 2)
                    {
                        if (int.Parse(_contentOfFile[i]) == _indexOfTheDeletedUser)
                        {
                            _contentOfFile[i] = "";
                            _contentOfFile[i + 1] = "";

                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length; j += 2)
                                {
                                    if (fileIsNotEmpty && _contentOfFile[j] != "" && _contentOfFile[j + 1] != "")
                                    {
                                        streamWriterTextFiles.Write($" {_contentOfFile[j]} {_contentOfFile[j + 1]}");
                                    }
                                    else if (_contentOfFile[j] != "" && _contentOfFile[j + 1] != "")
                                    {
                                        streamWriterTextFiles.Write($"{_contentOfFile[j]} {_contentOfFile[j + 1]}");
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
                throw new Exception("Can't delete award from text file.");
            }
        }
        public bool UpdateAward(Award award)
        {
            try
            {
                bool fileIsNotEmpty = false;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split();
                    for (int i = 0; i < _contentOfFile.Length; i += 2)
                    {
                        if (int.Parse(_contentOfFile[i]) == award.Id)
                        {
                            _contentOfFile[i + 1] = award.Title;

                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length; j += 2)
                                {
                                    if (fileIsNotEmpty && _contentOfFile[j] != "" && _contentOfFile[j + 1] != "")
                                    {
                                        streamWriterTextFiles.Write($" {_contentOfFile[j]} {_contentOfFile[j + 1]}");
                                    }
                                    else if (_contentOfFile[j] != "" && _contentOfFile[j + 1] != "")
                                    {
                                        streamWriterTextFiles.Write($"{_contentOfFile[j]} {_contentOfFile[j + 1]}");
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
                throw new Exception("Can't update award from text file.");
            }

        }
        public Award GetAwardById(int Id)
        {
            try
            {
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 2)
                        {
                            if (int.Parse(_contentOfFile[i]) == Id)
                            {
                                Award award = new Award();
                                award.Id = int.Parse(_contentOfFile[i]);
                                award.Title = _contentOfFile[i + 1];
                                return award;
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't get award from text file.");
            }
        }
        public IEnumerable<Award> GetAllAwards()
        {
            try
            {
                Dictionary<int, Award> _repoAward = new Dictionary<int, Award>();
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 2)
                        {
                            Award award = new Award();
                            award.Id = int.Parse(_contentOfFile[i]);
                            award.Title = _contentOfFile[i + 1];
                            _repoAward.Add(award.Id, award);
                        }
                        return _repoAward.Values;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't get all awards from text file.");
            }
        }
    }
}
