using Envision.MDM.Facility.Service.Interfaces;
using Envision.MDM.Location.API.Controllers;
using Envision.MDM.Location.Domain.AggregatesModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Envision.Facility.UnitTests.API
{
    /// <summary>
    /// Author:         @JohnG
    /// Date:           03/25/2018
    /// Description:    This is the unit test class to test the logic in all the method for 
    ///                 the facility API controller.
    /// </summary>
    public class FacilityControllerTest : IDisposable
    {
        private FacilityController _objectUnderTest; 

        [Fact]
        public void FacilityController_Null_Constructor_Test()
        {
            Assert.Throws<ArgumentException>(() => new FacilityController(null));
        }

        //[Fact]
        //public async Task GetFacilityById_and_Response_ok_status_code()
        //{
        //    int facilityId = 555;
        //    var mockRepo = new Mock<IFacilityService>();
        //    mockRepo.Setup(repo => repo.LoadFacilityById(facilityId))
        //        .ReturnsAsync(GetTestData());

        //    _objectUnderTest = new FacilityController(mockRepo.Object);

        //  //  var result = await _objectUnderTest.GetById(facilityId);

        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task GetFacilityByID_and_Return_KeyNotFoundException()
        //{
        //    int facilityId = 589585;
        //    var mockRepo = new Mock<IFacilityService>();
        //    mockRepo.Setup(repo => repo.LoadFacilityById(facilityId))
        //        .Throws<KeyNotFoundException>();

        //    _objectUnderTest = new FacilityController(mockRepo.Object);

        //    var result = await _objectUnderTest.GetById(facilityId);

        //    Assert.IsType<NotFoundResult>(result);
        //}


        //[Fact]
        //public async Task GetFacilityByID_and_Return_InternalServerError()
        //{
        //    int facilityId = 589585;
        //    var mockRepo = new Mock<IFacilityService>();
        //    mockRepo.Setup(repo => repo.LoadFacilityById(facilityId))
        //        .Throws<Exception>();

        //    _objectUnderTest = new FacilityController(mockRepo.Object);

        //    var result = await _objectUnderTest.GetById(facilityId);

        //    Assert.IsType<ObjectResult>(result);
            
        //}


        private MDM.Location.Domain.AggregatesModel.Facility GetTestData()
        {
            var address = new Address()
            {
                Street = "7700 W Sunrise Blvd ",
                City ="Fort Lauderdale",
                State = "FL",
                ZipCode = "33313",
                Country = "USA"
            };

            var facility = new MDM.Location.Domain.AggregatesModel.Facility(555)
            {
                Name = "Facility Test Name",
                LegalName = "Legal Facility Test Name",
                Address = address
            };
            

            return facility;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~FacilityControllerTest() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
