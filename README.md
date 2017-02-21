# Yuchen Liu For 永慶面試的專案題目 

## 本次實作 具有CRUD功能的 WEB API 

使用的項目僅有 Products 功能 含
+ 新增
+ 修改
+ 刪除
+ 查詢全部
+ 查詢BY ID

有關於 API 功能 SAMPLE 可下載 [postman json](https://www.getpostman.com/collections/77d710d7f95554fef65b) 匯入 [chrome postman extension](https://chrome.google.com/webstore/detail/postman/fhbjgbiflinjbdggehcddcbncdddomop?hl=zh-TW)

#實作相關技術

+ Object-Relational Mapping(ORM)
	- Entity Framework

+ ASP.Net MVC & WEBAPI
	- MVC 5 Web Api 2

+ Layered Architecture
	- Service layer

+ Dependency Injection (DI/IOC) 
	- Autofac

+ Unit Tests
	- NUnit
	
+ View Model Mapping
	- AutoMapper


# Sample

+ Create
```
{
    "ProductName": "Sample",
    "SupplierID": 1,
    "CategoryID": 1,
    "QuantityPerUnit": "24 - 12 oz bottles",
    "UnitPrice": 19,
    "UnitsInStock": 17,
    "UnitsOnOrder": 40,
    "ReorderLevel": 25,
    "Discontinued": false
}
```
