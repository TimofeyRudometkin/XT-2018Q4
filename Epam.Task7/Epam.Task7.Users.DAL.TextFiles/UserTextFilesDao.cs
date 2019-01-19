using Epam.Task._7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epam.Task7.Users.DAL.TextFiles
{
    public class UserTextFilesDao : IUserDao//, IAwardDao
    {
        private StringBuilder _pathOfTextFiles = new StringBuilder(@"C:\DirectoryWithTextFiles(Task7)");
        private StringBuilder _nameOfTextFileWithUsers = new StringBuilder("DateOfUsers.txt");
        private StringBuilder _nameOfTextFileWithUsersAndAwards = new StringBuilder("DateOfUsersAndAwards.txt");
        private string _contentOfFile1;
        private string[] _contentOfFile;
        private string[] SEPARATORS = { " <'> " };
        private string[] SEPARATORSLISTOFAWARDS = { " >'< " };

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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS,StringSplitOptions.RemoveEmptyEntries);
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
                    streamWriterTextFiles.Write($"{_maxIndex}{SEPARATORS[0]}{user.Name}{SEPARATORS[0]}{user.DateOfBirthday.ToShortDateString()}{SEPARATORS[0]}{user.Age}{SEPARATORS[0]}");
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
                int _indexOfTheDeletedUser = Id;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
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
                                    streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}{_contentOfFile[j + 2]}{SEPARATORS[0]}{_contentOfFile[j + 3]}{SEPARATORS[0]}");
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
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
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
                                    streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}{_contentOfFile[j + 2]}{SEPARATORS[0]}{_contentOfFile[j + 3]}{SEPARATORS[0]}");
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
        public bool ToAward(int userId, int awardId)
        {
            try
            {
                if (!File.Exists(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString())))
                {
                    if (!Directory.Exists(_pathOfTextFiles.ToString()))
                    {
                        Directory.CreateDirectory(_pathOfTextFiles.ToString());
                    }
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString()), true))
                    {
                        ;
                    }
                }
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < _contentOfFile.Length; i += 2)
                    {
                        if (int.Parse(_contentOfFile[i]) == userId)
                        {
                            _contentOfFile[i + 1] += _contentOfFile[i + 1] != ""
                                                   ? $"{SEPARATORSLISTOFAWARDS[0]}{awardId}"
                                                   : $"{awardId}";
                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length; j += 2)
                                {
                                    streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}");
                                }
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString()), false))
                    {
                        streamWriterTextFiles.Write($"{userId}{SEPARATORS[0]}{awardId}{SEPARATORS[0]}");
                    }
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't awarded user from text file.");
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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
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
        public int[] GetAwardsIdByUserId(int userId)
        {
            try
            {
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsersAndAwards.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < _contentOfFile.Length; i += 2)
                    {
                        if (int.Parse(_contentOfFile[i]) == userId)
                        {
                            string[] ListOfAwards;
                            ListOfAwards = _contentOfFile[i + 1].Split(SEPARATORSLISTOFAWARDS, StringSplitOptions.RemoveEmptyEntries);
                            int[] intListOfAwards = new int[ListOfAwards.Length];
                            for (int j=0; j< ListOfAwards.Length;j++)
                            {
                                intListOfAwards[j] = int.Parse(ListOfAwards[j]);
                            }
                            return intListOfAwards;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't awarded user from text file.");
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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
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
