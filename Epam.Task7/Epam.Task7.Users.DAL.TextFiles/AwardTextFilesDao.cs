using Epam.Task7._1.Users.DAL.Interface;
using Epam.Task7._1.Users.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Users.DAL.TextFiles
{
    class AwardTextFilesDao : IAwardDao
    {
        private static StringBuilder _pathOfTextFiles = new StringBuilder(@"C:\DirectoryWithTextFiles(Task7)");
        private static StringBuilder _nameOfTextFileWithAwards = new StringBuilder("DateOfAwards.txt");
        string _contentOfFile1;
        string[] _contentOfFile;
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
