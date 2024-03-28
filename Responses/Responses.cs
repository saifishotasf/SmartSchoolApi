using Utility;

namespace Responses
{
    /// Represents the responses of any type of object.    
    public static class Responses
    {

        /// Manages List type of resonses on success scenario.
        public static ApiListResponse<IEnumerable<T>> GetApiListResponce<T>(this IEnumerable<T> value)
        {
            if (value is not null)
            {
                return new ApiListResponse<IEnumerable<T>>
                {
                    Message = string.Format(Messages.Success),
                    IsSuccess = true,
                    Data = value,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiListResponse<IEnumerable<T>>
                {
                    Message = string.Format(Messages.NoRecordFound),
                    IsSuccess = true,
                    Data = value,
                    StatusCode = 404
                };

            }

              
        }

        /// Manages List type of resonses on success scenario.
        public static ApiResponse<T> GetApiResponce<T>(this T value, string placeHolder)
        {
            return new ApiListResponse<T>
            {
                Message = string.Format(Messages.Success),
                IsSuccess = true,
                Data = value,
                StatusCode = 200
            };
        }

        /// Manages Creation/failure of bojection response.
        public static ApiResponse<T> CreateResponse<T>(this T value, string placeHolder)
        {
            if (value is not null)
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.CreateSucess, placeHolder),
                    IsSuccess = true,
                    Data = value,
                    StatusCode = 201
                };
            }
            else
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.CreateFail, placeHolder),
                    IsSuccess = true,
                    Data = value,
                    StatusCode = 404
                };
            }
        }

        /// Manages Creation/failure of bojection response.
        public static ApiResponse<T> CreateResponseBool<T>(bool status, string placeHolder)
        {
            if (status)
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.CreateSucess, placeHolder),
                    IsSuccess = true,
                    StatusCode = 201
                };
            }
            else
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.CreateFail, placeHolder),
                    IsSuccess = true,
                    StatusCode = 404
                };
            }
        }
        /// Manages Update/failure of bojection response.
        public static ApiResponse<T> UpdateResponse<T>(bool status, string placeHolder)
        {
            if (status)
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.UpdateSucess, placeHolder),
                    IsSuccess = status,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.UpdateFail, placeHolder),
                    IsSuccess = status,
                    StatusCode = 404
                };
            }
        }
        public static ApiResponse<T> DeleteResponseMapper<T>(bool status, string placeHolder)
        {
            if (status)
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.DeleteSucess, placeHolder),
                    IsSuccess = status,
                    StatusCode = 200
                };
            }
            else
            {
                return new ApiResponse<T>
                {
                    Message = string.Format(Messages.DeleteFail, placeHolder),
                    IsSuccess = status,
                    StatusCode = 404
                };
            }
        }

        public static ApiResponse<T> ValidateResponse<T>(T value,string placeHolder1, string placeHolder2)
        {
            return new ApiResponse<T>
            {
                Message = string.Format(Messages.ValueExists, placeHolder1, placeHolder2),
                IsSuccess = false,
                StatusCode = 303 //Already Exist
            };

        }

        public static ApiResponse<T> CacheExceptionResponse<T>(this Exception ex)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }

        public static ApiListResponse<IEnumerable<T>> CacheExceptionListResponse<T>(this Exception ex)
        {
            return new ApiListResponse<IEnumerable<T>>
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }

        public static ApiResponse<T> BadRequestResponse<T>(T value, string placeHolder1)
        {
            return new ApiResponse<T>
            {
                Message = string.Format(Messages.BadRequest, placeHolder1),
                IsSuccess = false,
                StatusCode = 400
            };

        }

        public static ApiResponse<T> UnauthorizedResponse<T>(T value, string placeHolder1)
        {
            return new ApiResponse<T>
            {
                Message = string.Format(Messages.Unauthorized, placeHolder1),
                IsSuccess = false,
                StatusCode = 401
            };

        }

    }
}
