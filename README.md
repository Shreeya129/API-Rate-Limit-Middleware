# API Rate Limit Middleware

## 📌 Overview
This project implements a custom **API Rate Limiting Middleware** using **ASP.NET Core**.  
It controls the number of requests a client can make to an API within a specific time window, helping to protect the application from excessive usage, abuse, and performance degradation.

The middleware intercepts incoming HTTP requests, tracks request counts per client (based on IP address), and blocks further requests once the defined limit is exceeded.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

## 🚀 Features
- Custom ASP.NET Core Middleware
- IP-based request tracking
- Configurable request limits
- Prevents API abuse and overload
- Returns HTTP **429 (Too Many Requests)** when limit is exceeded
- Lightweight and easy to integrate into any ASP.NET Core API

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

## ⚙️ How It Works
1. A client sends an HTTP request to the API.
2. The Rate Limit Middleware intercepts the request before it reaches the controller.
3. The middleware checks how many requests the client has already made within the allowed time window.
4. If the request count is within the limit, the request is forwarded to the controller.
5. If the limit is exceeded, the middleware blocks the request and returns **HTTP 429 – Too Many Requests**.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------

## 🧠 Example Flow
