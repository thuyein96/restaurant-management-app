using OrderDto = RestaurantManagementApp.Dtos.Features.MenuItem.OrderDto;

namespace RestaurantManagementApp.Extension;

public static class Extension
{
    public static CategoryDto ToDto(this TblCategory dataModel)
    {
        return new CategoryDto
        {
            CategoryId = dataModel.CategoryId,
            CategoryName = dataModel.CategoryName
        };
    }

    public static TblCategory ToEntity(this CategoryDto categoryDto)
    {
        return new TblCategory
        {
            CategoryId = categoryDto.CategoryId,
            CategoryName = categoryDto.CategoryName
        };
    }

    public static TblCategory ToEntity(this CreateCategoryDto categoryDto)
    {
        return new TblCategory
        {
            CategoryName = categoryDto.CategoryName
        };
    }

    public static MenuItemDto ToDto(this TblMenuItem dataModel)
    {
        return new MenuItemDto
        {
            MenuItemId = dataModel.MenuItemId,
            MenuItemName = dataModel.MenuItemName,
            Description = dataModel.Description,
            Price = dataModel.Price,
            CategoryId = dataModel.CategoryId,
            Category = dataModel.Category.ToDto()
        };
    }

    public static TblMenuItem ToEntity(this CreateMenuItemDto menuItemDto)
    {
        return new TblMenuItem
        {
            MenuItemName = menuItemDto.MenuItemName,
            Description = menuItemDto.Description,
            Price = menuItemDto.Price,
            ImageUrl = menuItemDto.ImageUrl,
            CategoryId = menuItemDto.CategoryId,
            MenuItemCustomizeOptions = menuItemDto.CustomizeOptions
                .Select(x => new TblMenuItemCustomizeOption
            {
                CustomizeOptionId = x.CustomizeOptionId
            }).ToList()
        };
    }

    public static TblCustomizeOption ToEntity(this CreateCustomizeOptionDto customizeOptionDto)
    {
        return new TblCustomizeOption
        {
            Name = customizeOptionDto.CustomizeOptionName,
            Price = customizeOptionDto.Price
        };
    }

    public static TblCustomizeOption ToEntity(this CustomizeOptionDto customizeOptionDto)
    {
        return new TblCustomizeOption
        {
            CustomizeOptionId = customizeOptionDto.CustomizeOptionId,
            Name = customizeOptionDto.CustomizeOptionName,
            Price = customizeOptionDto.Price
        };
    }

    public static CustomizeOptionDto ToDto(this TblCustomizeOption customizeOption)
    {
        return new CustomizeOptionDto
        {
            CustomizeOptionId = customizeOption.CustomizeOptionId,
            CustomizeOptionName = customizeOption.Name,
            Price = customizeOption.Price
        };
    }

    public static MenuItemCustomizeOptionDto ToDto(this TblMenuItemCustomizeOption menuItemCustomizeOption)
    {
        return new MenuItemCustomizeOptionDto
        {
            MenuItemId = menuItemCustomizeOption.MenuItemId,
            CustomizeOptionId = menuItemCustomizeOption.CustomizeOptionId
        };
    }

    public static UserDto ToDto(this TblUser user)
    {
        return new UserDto
        {
            UserId = user.Id,
            UserName = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
    public static CustomerDto ToDto(this TblCustomer customer)
    {
        return new CustomerDto
        {
            CustomerId = customer.Id,
            UserId = customer.UserId,
            User = new UserDto
            {
                UserId = customer.UserId,
                UserName = customer.User.Name,
                Email = customer.User.Email,
                PhoneNumber = customer.User.PhoneNumber,
                CreatedAt = customer.User.CreatedAt,
                UpdatedAt = customer.User.UpdatedAt
            }
        };
    }

    public static TblCustomer ToEntity(this CustomerDto customerDto)
    {
        return new TblCustomer
        {
            Id = customerDto.CustomerId,
            UserId = customerDto.UserId,
            User = new TblUser
            {
                Id = customerDto.User.UserId,
                Name = customerDto.User.UserName,
                Email = customerDto.User.Email,
                PhoneNumber = customerDto.User.PhoneNumber,
                CreatedAt = customerDto.User.CreatedAt,
                UpdatedAt = customerDto.User.UpdatedAt
            }
        };
    }

    public static AdminDto ToDto(this TblAdmin admin)
    {
        return new AdminDto
        {
            AdminId = admin.Id,
            Password = admin.HashedPassword,
            UserId = admin.UserId,
            User = new UserDto
            {
                UserId = admin.UserId,
                UserName = admin.User.Name,
                Email = admin.User.Email,
                PhoneNumber = admin.User.PhoneNumber,
                CreatedAt = admin.User.CreatedAt,
                UpdatedAt = admin.User.UpdatedAt
            }
        };
    }

    public static TblAdmin ToEntity(this AdminDto adminDto)
    {
        return new TblAdmin
        {
            Id = adminDto.AdminId,
            HashedPassword = adminDto.Password,
            UserId = adminDto.UserId,
            User = new TblUser
            {
                Id = adminDto.User.UserId,
                Name = adminDto.User.UserName,
                Email = adminDto.User.Email,
                PhoneNumber = adminDto.User.PhoneNumber,
                CreatedAt = adminDto.User.CreatedAt,
                UpdatedAt = adminDto.User.UpdatedAt
            }
        };
    }

    public static CartItemDto ToDto(this TblCartItem cartItem)
    {
        return new CartItemDto
        {
            CartItemId = cartItem.Id,
            CartId = cartItem.CartId,
            Cart = cartItem.Cart.ToDto(),
            MenuItemId = cartItem.MenuItemId,
            Order = cartItem.MenuItem.ToDto(),
        };
    }

    public static TblCartItem ToEntity(this CreateCartItemDto cartItemDto)
    {
        return new TblCartItem
        {
            CartId = cartItemDto.CartId,
            MenuItemId = cartItemDto.MenuItemId,
            Quantity = cartItemDto.Quantity
        };
    }
    public static CartDto ToDto(this TblCart cart)
    {
        return new CartDto
        {
            CartId = cart.Id,
            CustomerId = cart.CustomerId,
            Total = cart.Total,
            CartItems = cart.CartItems
                .Select(x => x.ToDto())
                .ToList()
        };
    }

    public static TblCart ToEntity(this CreateCartDto cartDto)
    {
        return new TblCart
        {
            CustomerId = cartDto.CustomerId,
            Total = cartDto.Total,
            CartItems = cartDto.CartItems
                .Select(x => new TblCartItem
                {
                    Id = x.CartItemId,
                    CartId = x.CartId,
                    MenuItemId = x.MenuItemId
                })
                .ToList()
        };
    }
}