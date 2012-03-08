dwolla-sdk-dotnet
================================================================
Corey Oliver, 2012

An implementation of the Dwolla REST API using OAuth 2.0 in C#. The documentation for Dwolla's API can be found [here][1].

Setup Project in Visual Studio
----------------------------

1.   Open the `DwollaAPI.sln` with Visual Studio.
2.   Click on `Build > Rebuild Solution`.
3.   The .dll is copied to `..\Bin`.

Samples
-----

After building DwollaAPI.sln as described above, feel free to peruse and run the examples provided in the `Samples` directory:

1.   Open the Samples.sln file in Visual Studio.
2.   Define the `dwollaAppId` and `dwollaAppSecret` attributes in the `Web.config` file with your Dwolla application key and secret respectively.
2.   Right-click on a desired web project and click `View in Browser`.

Usage
-----

Instantiate an instance of the `DwollaClient` class assigning your Dwolla application key and secret to the `ClientIdentifier` and `ClientSecret` instance variables respectively:

    private static readonly DwollaClient client = new DwollaClient
    {
        ClientIdentifier = "hHLYjMVBBtl12+VKnzcFzCgXGO1lcjLARO7cJIQ8sEyCtzJaAT",
        ClientSecret = "HGJj2gbwCZuM4r3+4gbIEHfeJHfDebVmVOgfHBuRaWhO6XaEkL",
    };

Create a variable of type `IAuthorizationState` which will store the authorization response from Dwolla. If successful, it will store the access token; `null` otherwise:
         
    IAuthorizationState authorization = client.ProcessUserAuthorization();

Now you must request for user authorization from Dwolla while indicating the scope needed by any api calls you will make.

    client.RequestUserAuthorization(new Scope[] { Scope.REQUEST });


If authorized by the user, you can now perform any desired set of actions allowed by the scope(s) you indicated above: 

    var request = client.Request(authorization.AccessToken, 1111, "812-111-1111", 1, UserType.DWOLLA, null, "Test");

Todo
-----

*   Add method/class documentation  

[1]: https://www.dwolla.com/developers
