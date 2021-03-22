//
//  Copyright 2021  2021
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
namespace TTU_CORE_ASP_ADMISSION_PORTAL.Extensions
{
    using System.Security.Claims;
    using System.Security.Principal;

    namespace ProgramName.Models.Extensions
    {
        public static class IdentityExtensions
        {
            public static string FormNo(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
                // Test for null to avoid issues during local testing
                return (claim != null) ? claim.Value : string.Empty;
            }


            public static string Type(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Surname);
                // Test for null to avoid issues during local testing
                return (claim != null) ? claim.Value : string.Empty;
            }
        }
    }
}
