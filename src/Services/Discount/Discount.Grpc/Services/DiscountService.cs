using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) 
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName) 
                     ?? new Coupon { ProductName = "No Discount",Amount = 0, Description = "No Discount Description"};

        logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", 
            coupon.ProductName,coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }
}