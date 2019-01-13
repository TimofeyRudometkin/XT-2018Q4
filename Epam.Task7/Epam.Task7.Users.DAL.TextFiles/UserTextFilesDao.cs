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
                if(!File.Exists(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    if(!Directory.Exists(_pathOfTextFiles.ToString()))
                    {
                        Directory.CreateDirectory(_pathOfTextFiles.ToString());
                    }
                    File.CreateText(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()));
                }
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != null)
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 4)
                        {
                            _maxIndex = int.Parse(_contentOfFile[i]) > int.Parse(_contentOfFile[_maxIndex])
                                      ? i
                                      : _maxIndex;
                        }
                    }
                        using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()),true))
                        {
                            streamWriterTextFiles.WriteLine($"{_maxIndex} {user.Name} {user.DateOfBirthday} {user.Age}");
                        }
                    }
            }
            catch
            {
                throw new Exception("Can't add user to text file.");
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
                    if (_contentOfFile1 != null)
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
                                    for (int j = 0; i < _contentOfFile.Length; j += 4)
                                    {
                                        streamWriterTextFiles.WriteLine($"{_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j = 2]} {_contentOfFile[j + 3]}");
                                    }
                                }

                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            catch
            {
                throw new Exception("Can't delete user from text file.");
            }
        }
        public bool Update(User user)
        {
            try
            {
                int _indexOfTheUpdatedUser = user.Id;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != null)
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 4)
                        {
                            if (int.Parse(_contentOfFile[i]) == _indexOfTheUpdatedUser)
                            {
                                _contentOfFile[i] = user.Id.ToString();
                                _contentOfFile[i + 1] = user.Name.ToString();
                                _contentOfFile[i + 2] = user.DateOfBirthday.ToString();
                                _contentOfFile[i + 3] = user.Age.ToString();

                                using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), false))
                                {
                                    for (int j = 0; i < _contentOfFile.Length; j += 4)
                                    {
                                        streamWriterTextFiles.WriteLine($"{_contentOfFile[j]} {_contentOfFile[j + 1]} {_contentOfFile[j = 2]} {_contentOfFile[j + 3]}");
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            catch
            {
                throw new Exception("Can't update user from text file.");
            }

        }
        public User GetById(int Id)
        {
            try
            {
                int _indexOfTheGottenUser = Id;
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != null)
                    {
                        _contentOfFile = _contentOfFile1.Split();
                        for (int i = 0; i < _contentOfFile.Length; i += 4)
                        {
                            if (int.Parse(_contentOfFile[i]) == _indexOfTheGottenUser)
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
            catch
            {
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
                    if (_contentOfFile1 != null)
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
            catch
            {
                throw new Exception("Can't delete user from text file.");
            }
        }
    }
}
