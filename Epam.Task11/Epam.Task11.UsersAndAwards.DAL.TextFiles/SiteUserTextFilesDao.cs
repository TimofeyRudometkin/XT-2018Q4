using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.TextFiles
{
    public class SiteUserTextFilesDao : ISiteUserDao
    {
        private StringBuilder _pathOfTextFiles = new StringBuilder(@"C:\DirectoryWithTextFiles(Task7)");
        private StringBuilder _nameOfTextFileWithUsers = new StringBuilder("DateOfSiteUsers.txt");
        private string _contentOfFile1;
        private string[] _contentOfFile;
        private readonly string[] SEPARATORS = { " <'> " };
        private readonly string[] SEPARATORSLISTOFAWARDS = { " >'< " };

        public bool Add(string siteUserName, string userPassword)
        {
            try
            {
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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                        for (int i = 0; i < _contentOfFile.Length-1; i += 4)
                        {
                            if(_contentOfFile[i] == siteUserName)
                            {
                                return false;
                            }
                        }
                    }
                }
                using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), true))
                {
                    streamWriterTextFiles.Write($"{siteUserName}{SEPARATORS[0]}{userPassword}{SEPARATORS[0]}{SEPARATORS[0]}{SEPARATORS[0]}");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                //throw new Exception("Can't add user to text file.");
                return false;
            }
        }

        public bool AddImage(string siteUserName, string pathOfTheAddedImage)
        {
            throw new NotImplementedException(); 
        }

        public bool CorrectionOfAccessPermission(string siteUserName, bool admin)
        {
            try
            {
                bool _check = false;
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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                        for (int i = 0; i < _contentOfFile.Length - 1; i += 4)
                        {
                            if (_contentOfFile[i] == siteUserName)
                            {
                                _contentOfFile[i + 3] = admin.ToString();
                                _check = true;
                            }
                        }
                    }
                }
                if (_check)
                {
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), true))
                    {
                        for (int j = 0; j < _contentOfFile.Length - 1; j++)
                        {
                            streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}{_contentOfFile[j + 2]}{SEPARATORS[0]}{_contentOfFile[j + 3]}{SEPARATORS[0]}");
                        }
                    }
                }
                return _check;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                //throw new Exception("Can't add user to text file.");
                return false;
            }
        }

        public bool Delete(string siteUserName)
        {
            try
            {
                bool _check = false;
                int _indexSiteUserForDelete = -1;
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
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                        for (int i = 0; i < _contentOfFile.Length - 1; i += 4)
                        {
                            if (_contentOfFile[i] == siteUserName)
                            {
                                _indexSiteUserForDelete = i;
                                _check = true;
                            }
                        }
                    }
                }
                if (_check)
                {
                    using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), true))
                    {
                        for (int j = 0; j < _contentOfFile.Length - 1; j+=4)
                        {
                            if (j != _indexSiteUserForDelete)
                            {
                                streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}{_contentOfFile[j + 2]}{SEPARATORS[0]}{_contentOfFile[j + 3]}{SEPARATORS[0]}");
                            }
                        }
                    }
                }
                return _check;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                //throw new Exception("Can't add user to text file.");
                return false;
            }
        }

        public IEnumerable<SiteUser> GetAll()
        {
            try
            {
                Dictionary<string, SiteUser> _repoSiteUsers = new Dictionary<string, SiteUser>();
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                        for (int i = 0; i < _contentOfFile.Length-1; i += 4)
                        {
                            string[] ListOfAwards;
                            ListOfAwards = _contentOfFile[i + 2].Split(SEPARATORSLISTOFAWARDS, StringSplitOptions.RemoveEmptyEntries);
                            int[] intListOfAwards = new int[ListOfAwards.Length];
                            for (int j = 0; j < ListOfAwards.Length; j++)
                            {
                                intListOfAwards[j] = int.Parse(ListOfAwards[j]);
                            }
                            SiteUser SiteUser = new SiteUser
                            {
                                Name = _contentOfFile[i],
                                Password = _contentOfFile[i + 1],
                                AwardId = intListOfAwards,
                                AccessPermission = _contentOfFile[i + 3],
                            };
                            _repoSiteUsers.Add(SiteUser.Name, SiteUser);
                        }
                        return _repoSiteUsers.Values;
                    }
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.TargetSite + Environment.NewLine + e.StackTrace);
                throw new Exception("Can't get all users from text file.");
            }
        }

        public int[] GetAwardsIdBySiteUserName(string siteUserName)
        {
            try
            {
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                    for (int i = 0; i < _contentOfFile.Length - 1; i += 4)
                    {
                        if (_contentOfFile[i] == siteUserName)
                        {
                            if (_contentOfFile[i + 2] != "")
                            {
                                string[] ListOfAwards;
                                ListOfAwards = _contentOfFile[i + 2].Split(SEPARATORSLISTOFAWARDS, StringSplitOptions.RemoveEmptyEntries);
                                int[] intListOfAwards = new int[ListOfAwards.Length];
                                for (int j = 0; j < ListOfAwards.Length; j++)
                                {
                                    intListOfAwards[j] = int.Parse(ListOfAwards[j]);
                                }
                                return intListOfAwards;
                            }
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

        public SiteUser GetBySiteUserName(string siteUserName)
        {
            try
            {
                using (StreamReader streamReaderTextFiles = new StreamReader(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString())))
                {
                    _contentOfFile1 = streamReaderTextFiles.ReadToEnd();
                    if (_contentOfFile1 != "")
                    {
                        _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                        for (int i = 0; i < _contentOfFile.Length-1; i += 4)
                        {
                            if (_contentOfFile[i] == siteUserName)
                            {
                                string[] ListOfAwards;
                                ListOfAwards = _contentOfFile[i + 2].Split(SEPARATORSLISTOFAWARDS, StringSplitOptions.RemoveEmptyEntries);
                                int[] intListOfAwards = new int[ListOfAwards.Length];
                                for (int j = 0; j < ListOfAwards.Length; j++)
                                {
                                    intListOfAwards[j] = int.Parse(ListOfAwards[j]);
                                }
                                SiteUser siteUser = new SiteUser
                                {
                                    Name = _contentOfFile[i],
                                    Password = _contentOfFile[i + 1],
                                    AwardId = intListOfAwards,
                                    AccessPermission = _contentOfFile[i + 3],
                                };
                                return siteUser;
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

        public bool ToAwardSiteUser(string siteUserName, int awardId)
        {
            try
            {
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
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                    for (int i = 0; i < _contentOfFile.Length-1; i += 4)
                    {
                        if (_contentOfFile[i] == siteUserName)
                        {
                            _contentOfFile[i + 2] += _contentOfFile[i + 2] != ""
                                                   ? $"{SEPARATORSLISTOFAWARDS[0]}{awardId}"
                                                   : $"{awardId}";
                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length-1; j += 4)
                                {
                                    streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j+1]}{SEPARATORS[0]}{_contentOfFile[j+2]}{SEPARATORS[0]}{_contentOfFile[j+3]}{SEPARATORS[0]}");
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
                throw new Exception("Can't awarded user from text file.");
            }
        }

        public bool ToRemoveSiteUserReward(string siteUserName, int awardId)
        {
            try
            { 
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
                }
                if (_contentOfFile1 != "")
                {
                    _contentOfFile = _contentOfFile1.Split(SEPARATORS, StringSplitOptions.None);
                    for (int i = 0; i < _contentOfFile.Length - 1; i += 4)
                    {
                        if (_contentOfFile[i] == siteUserName)
                        {
                            _contentOfFile1 = "";
                            string[] _contentOfFile2 = _contentOfFile[i + 1].Split(SEPARATORSLISTOFAWARDS, StringSplitOptions.RemoveEmptyEntries);
                            for (int j = 0; j < _contentOfFile2.Length; j++)
                            {
                                if (_contentOfFile2[j] != awardId.ToString())
                                {
                                    _contentOfFile1 += SEPARATORSLISTOFAWARDS[0] + _contentOfFile2[j];
                                }
                            }
                            _contentOfFile[i + 1] = _contentOfFile1;
                            using (StreamWriter streamWriterTextFiles = new StreamWriter(Path.Combine(_pathOfTextFiles.ToString(), _nameOfTextFileWithUsers.ToString()), false))
                            {
                                for (int j = 0; j < _contentOfFile.Length - 1; j += 2)
                                {
                                    streamWriterTextFiles.Write($"{_contentOfFile[j]}{SEPARATORS[0]}{_contentOfFile[j + 1]}{SEPARATORS[0]}");
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
                throw new Exception("Can't awarded user from text file.");
            }
        }
    }
}
