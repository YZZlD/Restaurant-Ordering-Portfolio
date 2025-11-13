import CartItemCard from "./cartItemCard";
import MenuItemCard from "./menuItemCard";

export default function OrderCart({cart}: {cart:any[]})
{
    return (
        <div className="sticky top-40 m-10 h-1/2 col-start-7 col-span-4 bg-gray-300 border-4 border-black rounded-md">
                <div className="relative">
                    <h1 className="header">Your Cart</h1>
                </div>
                {cart.map(item => (
                    <div key={item.id} className="">
                        <CartItemCard key={item.id} cartItem={item} />
                    </div>
                ))}
        </div>
        
    )
}
