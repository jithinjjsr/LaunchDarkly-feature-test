# LaunchDarkly Feature Flag Demo in .NET 8

This is a demo application that integrates LaunchDarkly feature flags in an ASP.NET Core Web API using .NET 8.

## **Prerequisites**
- .NET 8 SDK installed ([Download .NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- A [LaunchDarkly](https://launchdarkly.com) account
- Postman or a browser for testing API requests

---

## **Setup Instructions**

### **1. Clone the Repository**
```sh
 git clone https://github.com/your-repo/launchdarkly-dotnet8-demo.git
 cd launchdarkly-dotnet8-demo
```

### **2. Install Dependencies**
```sh
dotnet restore
```

### **3. Install the LaunchDarkly SDK**
```sh
dotnet add package LaunchDarkly.ServerSdk
```

### **4. Configure LaunchDarkly**
1. Sign in to [LaunchDarkly](https://launchdarkly.com) and create a new **Project** and **Environment**.
2. Go to **Feature Flags** and create a new flag named `new-feature`.
3. Copy your **SDK Key** from the LaunchDarkly dashboard.
4. Add the SDK Key to your environment variables or `appsettings.json`.

```json
{
  "LaunchDarkly": {
    "SdkKey": "YOUR_LAUNCHDARKLY_SDK_KEY"
  }
}
```

### **5. Run the Application**
```sh
dotnet run
```

The API will start at `http://localhost:5000` (or another available port).

---

## **API Endpoints**

### **1. Check Feature Flag Status (Route Parameter)**
#### **Request:**
```
GET http://localhost:5000/api/features/new-feature/user-123
```
#### **Response (if flag is enabled):**
```json
{
  "message": "New Feature is ENABLED!",
  "user": "user-123"
}
```

#### **Response (if flag is disabled):**
```json
{
  "message": "New Feature is DISABLED!",
  "user": "user-123"
}
```

### **2. Check Feature Flag Status (Query Parameter)**
#### **Request:**
```
GET http://localhost:5000/api/features/new-feature?userKey=user-123
```
#### **Response:** (same as above)

---

## **Cleanup and Best Practices**
- **Disposing the SDK Properly**: Ensure `LdClient` is disposed when the application shuts down.
- **Environment Variables**: Store the LaunchDarkly SDK Key securely instead of hardcoding it.

---

## **Further Improvements**
- Integrate LaunchDarkly in an **Angular frontend**.
- Implement **percentage rollouts** for gradual feature releases.
- Use **context attributes** (e.g., roles, location) for dynamic targeting.

For more details, visit the [LaunchDarkly .NET SDK Documentation](https://docs.launchdarkly.com/sdk/server-side/dotnet).

---

## **Contributing**
Feel free to fork this repository and submit pull requests for improvements!

---

## **License**
This project is licensed under the MIT License.

