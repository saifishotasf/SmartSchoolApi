﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Messages
    {
        public static string AccessRightError = "{0} must have at least one access rights";
        public static string AccessRightInvalid = "Invalid access rights in request";
        public static string AccountLock = "Your account has been locked due to {0} invalid login attempts";
        public static string BadRequest = "Request is not valid as {0} does not exist";
        public static string BlankEmptyError = "{0} required, can not be blank.";
        public static string CreateFail = "{0} creation failed";
        public static string CreateSucess = "{0} created successfully";
        public static string ProfileCreateSucess = "{0} Registered successfully";
        public static string DataInValid = "Provided data is not valid";
        public static string DeleteFail = "Delete failed for {0}";
        public static string DeleteSucess = "{0} deleted successfully";
        public static string EmailInvalid = "One of emailid is not valid";
        public static string FileError = "Error occurs while generating file";
        public static string FileUploadSuccess = "Image Proof {0} has successfully uploaded";
        public static string InternalServerError = "Internal server error occured. Please try after sometime";
        public static string InvalidCombinationOfAccessRights = "Invalid combination of access rights";
        public static string InvalidCredentials = "Invalid Credentials";
        public static string InValidInputMsg = "Invalid input data in request";
        public static string InvalidParameterInRequest = "Invalid {0} in request";
        public static string LoginFail = "Provided username or password is incorrect";
        public static string MACAddOrBrowserEmpty = "MACAddress or Browser is not provided";
        public static string MIMEErrorMeesage = "MIME multipart message is not complete";
        public static string MultiPhotoUploadException = "Invalid request, only single photo upload supported";
        public static string NoRecordFound = "No records found to proceed request";
        public static string NoRecordsForFile = "No records found to download file";
        public static string OldNewSamePassword = "New password must not be same as old password";
        public static string OTPExpired = "Entered OTP is expired";
        public static string OTPIncorrect = "Entered OTP is wrong";
        public static string OTPFail = "Fail to generate OTP";
        public static string OTPResend = "OTP re-generated successfully";
        public static string OTPValidated = "OTP Successfully validated";
        public static string OTPMessage = "{0} is your Secrete One Time Password(OTP) for AMCManager Portal.";
        public static string PasswordExpire = "User password is expired";
        public static string PasswordWrong = "Current password is wrong";
        public static string PhotoInvalidExtenssion = "Invalid image format. Only jpg or jpeg are supported";
        public static string PhotoUploadNoAttachment = "There is no attachment in request, please attach Image to upload";
        public static string RequiredData = "{0} is required";
        public static string Success = "Data Retrived Successfully";
        public static string UnlockFail = "User unlocked failed for listed users";
        public static string UnlockSuccess = "User unlocked successfully";
        public static string UpdateFail = "{0} updation failed";
        public static string UpdateSucess = "{0} updated successfully";
        public static string UserOrPasswordEmpty = "Username or Password is not provided";
        public static string ValueExists = "{0} {1} already exists";
        public static string ValueNotExists = "{0} does not exists";
        public static string ValueNotValid = "{0} is not valid";
        public static string Unauthorized = "{0} is not authorized";
    }
}
