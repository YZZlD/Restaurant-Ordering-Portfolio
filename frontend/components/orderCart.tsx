import CartItemCard from "./cartItemCard";
import { postOrder } from "@/app/src/APIHandling";
import { redirect } from 'next/navigation'
import { useState } from "react";

export default function OrderCart({cart, modifyTotal, total, removeLastItem, setItemInCart}: {cart:any[], modifyTotal:Function, total:number, removeLastItem:Function, setItemInCart:Function})
{
    const [isDisabled, setIsDisabled] = useState(false);

    return (
        <div className="sticky top-40 m-10 h-1/2 col-start-7 col-span-4 bg-gray-300 border-4 border-black rounded-md overflow-y-auto space-y-4">
                <div className="sticky top-0 z-5 bg-black">
                    <h1 className="header">Your Cart</h1>
                </div>
                <div className="h-3/4 space-y-3 my-4">
                    {cart.map(item => (
                        <div key={item.itemInfo.menuItemId} className="px-2">
                            <CartItemCard setItemInCart={(id:number) => setItemInCart(id)}removeLastItem={(id:number) => removeLastItem(id)} cartItem={item} modifyTotal={(value:number) => modifyTotal(value)} />
                        </div>
                    ))}
                </div>
                <div className="w-full bottom-0 h-30 z-5 bg-black flex space-x-10 p-10">
                    <h1 className="header">Total: </h1>
                    <h1 className="header">{Math.abs(total).toFixed(2)}</h1>
                    <button onClick={async () => {setIsDisabled(true); await postOrder(cart); redirect('/api')}} disabled={isDisabled} className=" bg-white hover:bg-gray-300 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow">Submit Order</button>
                </div>
        </div>

    )
}
