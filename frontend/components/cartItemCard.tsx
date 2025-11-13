'use client'

import { libreBaskerville } from "@/app/ui/fonts"
import { useState } from "react"

export default function CartItemCard({cartItem, modifyTotal, removeLastItem}: {cartItem:any, modifyTotal:Function, removeLastItem:Function}){

    const [quantity, setQuantity] = useState(1);

    const decrementQuantity = () => {
        modifyTotal(cartItem.itemInfo.price * -1);

        if(cartItem.quantity <= 1) {
            removeLastItem(cartItem.itemInfo.id);
            return;
        }
        
        cartItem.quantity--;
        setQuantity(quantity => quantity -= 1);
    }

    const incrementQuantity = () => {
        cartItem.quantity++;

        modifyTotal(cartItem.itemInfo.price);
        setQuantity(quantity => quantity += 1);
    }

    return (
        <div className="grid grid-cols-10 border-2 border-black rounded-lg items-center h-20 bg-red-200">
            <div className="grid col-start-1 col-span-4 grid-cols-1 ms-10">
                <h1 className="text-xl text-black">{cartItem.itemInfo.name}</h1>
            </div>
            <div className="flex justify-center col-start-5 col-span-2">
                <p className="text-2xl text-black"><strong>${cartItem.itemInfo.price}</strong></p>
            </div>
            <div className="flex justify-center col-start-7 col-span-4">
                <div className="relative grid grid-cols-10 h-1/3 w-1/2">
                    <button className="col-start-1 col-span-3 rounded-s-xl border-2 border-black bg-red-700 hover:bg-red-400" onClick={() => decrementQuantity()}>-</button>
                    <div className="col-start-4 col-span-4 border-2 border-black bg-white">
                        <p className="text-center text-black">{quantity}</p>
                    </div>
                    <button className="col-start-8 col-span-3 rounded-e-xl border-2 border-black bg-red-700 hover:bg-red-400" onClick={() => incrementQuantity()}>+</button>
                </div>
            </div>
        </div>
    )
}