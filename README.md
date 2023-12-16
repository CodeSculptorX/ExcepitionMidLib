# ExcepitionMidLib

ExcepitionMidLib is a .NET Core class library designed to handle exceptions in a structured and efficient manner.And ExcepitionMidLib library also for handling global exceptions and maintaining global response. This library is used to generate standardized responses for successful and error scenarios.

### Prerequisites

Before you begin, ensure you have met the following requirements:

1. **.NET Core**: You should have .NET Core installed on your machine. The library is written in .NET Core, so you need it to use the library.

2. **IDE**: You need an Integrated Development Environment (IDE) that supports .NET Core development. Visual Studio, Visual Studio Code, or JetBrains Rider are good options.

3. **Knowledge**: Basic knowledge of C# and .NET Core is required to use this library effectively. Familiarity with exception handling in .NET Core would be beneficial.

4. **.NET Core Project**: You need an existing .NET Core project to use this library. The library is not available as a NuGet package and needs to be included directly in your project.

Please ensure all these prerequisites are met before attempting to use the `ExcepitionMidLib` library.

## Structure

The library is organized into several key components:

1. **Builder/middleware/ExceptionMiddlewareExtensions.cs**: This class contains the `UserExceptionHandler` method, which sets up the middleware for handling API exceptions.

2. **common/Constants.cs**: This file defines several constants that are used as JSON keys in API error and response messages.

3. **Exception**: This directory contains several classes related to exception handling:
    - **APIException.cs**: This class is a custom exception designed to handle API errors. It inherits from the `BaseException` class.
    - **BaseException.cs**: This class serves as the base class for other exception classes in the library.
    - **DatabaseException.cs**: This class handles exceptions related to database operations.
    - **Error.cs**: This class represents an error in the application.
    - **ExceptionOptions.cs**: This class provides configurable options for exceptions, such as default error codes.

4. **Middleware/ExceptionHandler/APIExceptionResponceMiddleware.cs**: This class is a middleware that handles API exceptions and formulates a response.
5. **Models/HttpActionResponce.cs**: This class represents the HTTP response from an action. It includes properties such as `TrackingId`, `UserMessage`, `DeveloperMessage`, `Data`, and `StatusCode`.


## Usage

To use this library, simply include it in your .NET Core project and configure the middleware to use the `UserExceptionHandler` method from `ExceptionMiddlewareExtensions.cs`.

Here's an example of how to register the library in your application:

```csharp
app.UserExceptionHandler(options =>
{
    options.DefaultInternalServerErrorCode = 500;
    options.DefaultDatabaseErrorCode = 400;
});
```

### Response

An error response includes the following fields:

- `trackingid`: A unique identifier for tracking the error.
- `usermessage`: A user-friendly error message.
- `developerMessage`: A developer-specific error message.
- `data`: Additional data related to the error.
- `statuscode`: The HTTP status code indicating the type of error.

Example Error Response:

```json
{
  "trackingid": "ea9e0805-f615-486c-913a-13c09baa30fe",
  "usermessage": "Product is not exists.",
  "developerMessage": null,
  "data": null,
  "statuscode": 406
}
```
Successful Response

```json
{
  "trackingId": "85fef669-292f-4dbb-8f2c-888e8fc88cbd",
  "userMessage": null,
  "developerMessage": null,
  "data": [
    {
      "id": 1,
      "productname": "Mango",
      "price": 0,
      "productdetails": "Mongo product"
    },
    {
      "id": 2,
      "productname": "Apple",
      "price": 56,
      "productdetails": "Apple product"
    }
  ],
  "statusCode": 200
}
```

# All Rights Reserved License

© Vivek Patel

All rights to this software and associated documentation are reserved. You may only view this code for educational or reference purposes. Any use, copy, modification, distribution, or other action with this code is strictly prohibited without explicit written permission from the copyright holder.

If you are interested in using this code or any part of it, please contact 	mr.vivekjpatel@gmail.com for licensing and permissions.

THIS SOFTWARE IS PROVIDED "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
