# 🧩 Game Store Backend – Learning Roadmap

A personal backend project inspired by game distribution platforms like Steam, GOG, Epic Games Store.  
Technologies: ASP.NET Core, Entity Framework, AWS, REST APIs

---

## 🔹 Phase 1 – Setup & Account Management

**Goal:** Build the foundation with user registration and login.

| Feature           | Tech Stack                            | Skills Gained                         | Status |
|------------------|----------------------------------------|---------------------------------------|--------|
| Project setup     | ASP.NET Core, EF Core                  | Backend architecture                  | ⬅️     |
| Register/Login    | ASP.NET Identity / JWT / AWS Cognito   | Authentication & security             | 🕐     |
| User profile API  | REST endpoints                         | Role-based auth, token handling       | 🕐     |

---

## 🔹 Phase 2 – Game Catalog

**Goal:** Create a browsable and filterable game catalog.

| Feature            | Tech Stack         | Skills Gained                      | Status |
|-------------------|--------------------|------------------------------------|--------|
| Game model/schema | Entity Framework   | Data modeling, migrations          | 🕐     |
| Catalog API       | REST + LINQ        | Filtering, sorting, pagination     | 🕐     |
| Admin game upload | Admin routes + CRUD| Access control, input validation   | 🕐     |

---

## 🔹 Phase 3 – Purchases & Game Library

**Goal:** Allow users to buy games and access their own library.

| Feature           | Tech Stack                         | Skills Gained                        | Status |
|------------------|-------------------------------------|--------------------------------------|--------|
| Fake checkout     | Stripe API (test) / logic mock      | Payment integration                  | 🕐     |
| Game ownership    | EF relational data                  | N:N relations, authorization         | 🕐     |
| Game downloads    | Signed URL or secure route          | Content protection                   | 🕐     |

---

## 🔹 Phase 4 – Game File Hosting (AWS)

**Goal:** Upload and serve games securely from cloud storage.

| Feature           | Tech Stack               | Skills Gained                         | Status |
|------------------|--------------------------|---------------------------------------|--------|
| Upload games      | AWS S3                   | Cloud storage                         | 🕐     |
| Protected downloads| Signed URLs, CloudFront | Access control, CDN                   | 🕐     |
| Download stats    | CloudWatch (optional)    | Monitoring, data insights             | 🕐     |

---

## 🔹 Phase 5 – CI/CD & Deployment

**Goal:** Make your backend deployable and production-ready.

| Feature           | Tech Stack                               | Skills Gained                      | Status |
|------------------|--------------------------------------------|------------------------------------|--------|
| Cloud deploy      | AWS Elastic Beanstalk / ECS Fargate       | Docker, DevOps basics              | 🕐     |
| Remote DB         | AWS RDS                                   | Cloud database management          | 🕐     |
| CI/CD pipeline    | GitHub Actions + AWS                      | Automated deployment               | 🕐     |

---

## 🔸 Optional / Advanced Features

| Feature                 | Tech Stack (suggested)              | Skills Gained                      | Status |
|-------------------------|-------------------------------------|------------------------------------|--------|
| Game ratings & reviews  | EF Core, Auth                       | Relational data + auth             | 🕐     |
| Wishlist system         | REST + DB                           | User-linked data                   | 🕐     |
| Multi-language support  | i18n, resource files                | Localization                       | 🕐     |
| Notification system     | AWS SNS / Email                     | Messaging systems                  | 🕐     |
| Tags & categories       | EF Core, Filters                    | Categorization, filtering          | 🕐     |

---

## 🧠 Reusability: E-commerce vs Game Distribution

| Feature         | Shared Skill             | AWS Application                 | Status |
|----------------|--------------------------|----------------------------------|--------|
| User auth       | JWT / OAuth              | Cognito, IAM                     | 🕐     |
| Product catalog | REST APIs, search        | API Gateway, Lambda              | 🕐     |
| Payments        | Stripe, logic            | SNS/SQS for events               | 🕐     |
| File handling   | Media/files              | S3, CloudFront                   | 🕐     |
| Database        | SQL, EF Core             | RDS (PostgreSQL/MySQL)          | 🕐     |
| CI/CD           | GitHub Actions           | CodePipeline / CodeBuild        | 🕐     |
| Monitoring      | Logs, stats              | CloudWatch, X-Ray               | 🕐     |

---

✅ Start with **Phase 1**, and update the `Status` column as you make progress!
