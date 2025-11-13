import { useState } from "react";
import CartItemCard from "./cartItemCard";
import MenuItemCard from "./menuItemCard";

export default function OrderCart({cart, modifyTotal, total, removeLastItem, setItemInCart}: {cart:any[], modifyTotal:Function, total:number, removeLastItem:Function, setItemInCart:Function})
{
    return (
        <div className="sticky top-40 m-10 h-1/2 col-start-7 col-span-4 bg-gray-300 border-4 border-black rounded-md overflow-y-auto space-y-4">
                <div className="sticky top-0 z-5 bg-black">
                    <h1 className="header">Your Cart</h1>
                </div>
                {cart.map(item => (
                    <div key={item.itemInfo.id} className="px-2">
                        <CartItemCard setItemInCart={(id:number) => setItemInCart(id)}removeLastItem={(id:number) => removeLastItem(id)} cartItem={item} modifyTotal={(value:number) => modifyTotal(value)} />
                    </div>
                ))}
                <div className="absolute w-full bottom-0 h-30 z-5 bg-black">
                    <h1>{Math.abs(total).toFixed(2)}</h1>
                </div>
        </div>
        
    )
}
