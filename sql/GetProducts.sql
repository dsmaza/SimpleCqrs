create view GetProducts
as
select p.Id,
	   p.Title,
	   p.Price,
	   c.Name as CategoryName
from dbo.Product p
left join dbo.ProductCategory pc on p.Id=pc.ProductId
left join dbo.Category c on pc.CategoryId=c.Id