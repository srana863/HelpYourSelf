using Layer.Business.Common;
using Layer.Business.Interfaces;
using Layer.Data.DLL.Tutorial;
using Layer.Data.Interfaces;
using Layer.Model.Common;
using Layer.Model.Model.Tutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Layer.Business.BAL.Tutorial
{
    using Layer.Model.Enums;

    public class TutorialManager : BllCommon, ITutorialManager
    {
        private readonly ITutorialRepository _tutorialRepository;
        public TutorialManager()
        {
            _tutorialRepository = new TutorialRepository(_dbContext);
        }
        public ReturnMessage Save(Tutorials tutorial, AppSession appSession)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    _dbContext.Open();
                    var isSaved = 0;
                    var oldTutorial = _tutorialRepository.Get(tutorial.TutorialId);
                    if (oldTutorial == null)
                    {
                        var model = new Tutorials
                        {
                            Title = tutorial.Title,
                            UserId = appSession.UserInfo.UserId,
                            CategoryId = (int)TutorialCategory.Tutorial,
                            AvgRating = 0,
                            Meta = tutorial.Meta,
                            IsActive = true,
                            Description = tutorial.Description,
                            TotalView = 0,
                            TotalRatingGivenCount = 0,
                            TotalLikeCount = 0,
                            TotalWorkedCount = 0,
                            IsReviewd = false,
                            ShowInHomePage = false,
                            AddedBy = appSession.UserInfo.UserId,
                            AddedDate = DateTime.UtcNow

                        };
                        isSaved = _tutorialRepository.Create(model);
                        _vmReturn = isSaved > 0 ? ReturnMessage.SetSuccessMessage("Tutorial submitted successfully, waiting for review") : ReturnMessage.SetErrorMessage("Failed to submit tutorial!");
                    }
                    else
                    {
                        var model = new Tutorials
                        {
                            Title = tutorial.Title,
                            CategoryId = oldTutorial.CategoryId,
                            AvgRating = oldTutorial.AvgRating,
                            Meta = tutorial.Meta,
                            IsActive = true,
                            Description = tutorial.Description,
                            TotalView = oldTutorial.TotalView,
                            TotalRatingGivenCount = oldTutorial.TotalRatingGivenCount,
                            TotalLikeCount = oldTutorial.TotalLikeCount,
                            TotalWorkedCount = oldTutorial.TotalWorkedCount,
                            IsReviewd = false,
                            ShowInHomePage = false,
                            UpdateBy = appSession.UserInfo.UserId,
                            UpdateDate = DateTime.UtcNow

                        };
                        isSaved = _tutorialRepository.Update(model);
                        _vmReturn = isSaved > 0 ? ReturnMessage.SetSuccessMessage("Tutorial updated successfully, waiting for review") : ReturnMessage.SetErrorMessage("Failed to submit tutorial!");
                    }
                    if (isSaved > 0)
                    {
                        transactionScope.Complete();
                        transactionScope.Dispose();
                    }
                    else
                    {
                        return ReturnMessage.SetInfoMessage("Somethings wrongs! Couldn't submit tutorial!");
                    }
                    return _vmReturn;
                }
                catch(Exception e)
                {
                    transactionScope.Dispose();
                    return _vmReturn;
                }
                finally
                {
                    _dbContext.Close();
                }
            }

        }
        
        public Tutorials Get(int id)
        {
            if (id <= 0)
                return null;
            try
            {
                _dbContext.Open();
                return _tutorialRepository.Get(id);

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public IEnumerable<Tutorials> GetAllTutorialByUserId(long UserId)
        {
            if (UserId <= 0)
                return null;
            try
            {
                _dbContext.Open();
                return _tutorialRepository.GetAllTutorialByUserId(UserId);

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public IEnumerable<Tutorials> GetAll()
        {
            try
            {
                _dbContext.Open();
                return _tutorialRepository.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

        public ReturnMessage Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
