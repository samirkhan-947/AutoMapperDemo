﻿// See https://aka.ms/new-console-template for more information
using AutoMapper;

Console.WriteLine("Hello, World!");

//Step1: Initialize the Mapper
var mapper = InitializeAutomapper();
//Step2: Create the Order Request
var OrderRequest = CreateOrderRequest();
//Step3: Map the OrderRequest object to Order DTO
var orderDTOData = mapper.Map<Order, OrderDTO>(OrderRequest);

//Step4: Print the OrderDTO Data
Console.WriteLine("After Mapping - OrderDTO Data");
Console.WriteLine("OrderId : " + orderDTOData.OrderId);
Console.WriteLine("NumberOfItems : " + orderDTOData.NumberOfItems);
Console.WriteLine("TotalAmount : " + orderDTOData.TotalAmount);
Console.WriteLine("CustomerId : " + orderDTOData.customer.CustomerID);
Console.WriteLine("FullName : " + orderDTOData.customer.FullName);
Console.WriteLine("Postcode : " + orderDTOData.customer.Postcode);
Console.WriteLine("ContactNo : " + orderDTOData.customer.ContactNo);
Console.WriteLine();
//Step5: modify the OrderDTO data
orderDTOData.OrderId = 10;
orderDTOData.NumberOfItems = 20;
orderDTOData.TotalAmount = 2000;
orderDTOData.customer.CustomerID = 5;
orderDTOData.customer.FullName = "James Smith";
orderDTOData.customer.Postcode = "12345";
//Step6: Reverse Map
mapper.Map(orderDTOData, OrderRequest);

//Step7: Print the Order Data
Console.WriteLine("After Reverse Mapping - Order Data");
Console.WriteLine("OrderNo : " + OrderRequest.OrderNo);
Console.WriteLine("NumberOfItems : " + OrderRequest.NumberOfItems);
Console.WriteLine("TotalAmount : " + OrderRequest.TotalAmount);
Console.WriteLine("CustomerId : " + OrderRequest.CustomerId);
Console.WriteLine("Name : " + OrderRequest.Name);
Console.WriteLine("Postcode : " + OrderRequest.Postcode);
Console.WriteLine("MobileNo : " + OrderRequest.MobileNo);
Console.ReadLine();

 static Order CreateOrderRequest()
{
    return new Order
    {
        OrderNo = 101,
        NumberOfItems = 3,
        TotalAmount = 1000,
        CustomerId = 777,
        Name = "James Smith",
        Postcode = "755019",
        MobileNo = "1234567890"
    };
}

static Mapper InitializeAutomapper()
{
    var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Order, OrderDTO>()
             .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo)) //column differnt mapping
             .ForMember(dest => dest.customer, act => act.MapFrom(src => new Customer()
             {
                 CustomerID = src.CustomerId,
                 FullName = src.Name,
                 Postcode = src.Postcode,
                 ContactNo = src.MobileNo
             }))
             .ReverseMap()
             .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.customer.CustomerID))
             .ForMember(dest => dest.Name, act => act.MapFrom(src => src.customer.FullName))
             .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.customer.ContactNo))
             .ForMember(dest => dest.Postcode, act => act.MapFrom(src => src.customer.Postcode));
    });

    var mapper = new Mapper(config);
    return mapper;
}
public class Order
{
    public int OrderNo { get; set; }
    public int NumberOfItems { get; set; }
    public int TotalAmount { get; set; }
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Postcode { get; set; }
    public string MobileNo { get; set; }
}
public class Customer
{
    public int CustomerID { get; set; }
    public string FullName { get; set; }
    public string Postcode { get; set; }
    public string ContactNo { get; set; }
}
public class OrderDTO
{
    public int OrderId { get; set; }
    public int NumberOfItems { get; set; }
    public int TotalAmount { get; set; }
    public Customer customer { get; set; }
}