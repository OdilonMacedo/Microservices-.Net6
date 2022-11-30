using System.Threading.Tasks;
using GeekShopping.CartAPI.Data.ValueObjects;
using Microsoft.Extensions.Primitives;

namespace GeekShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string CouponCode, string token);
    }
}
