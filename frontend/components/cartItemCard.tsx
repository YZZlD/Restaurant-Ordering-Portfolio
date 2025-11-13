'use client'

import { libreBaskerville } from "@/app/ui/fonts"
import { useState } from "react"

export default function CartItemCard({cartItem}: {cartItem:any}){

    const [quantity, setQuantity] = useState(cartItem.quantity);

    return (
        //THIS IS THE WHOLE CARD
                <div className="relative w-100 h-125 border-4 border-black bg-red-700 rounded-xl">
                    {/* THIS IS THE IMAGE DIV */}
                    <div className="relative w-full h-1/2 border-4 border-white rounded-md">
                        <div className="relative w-full h-full">
                            <img alt={cartItem.itemInformation.name} src={cartItem.itemInformation.src} className="object-cover h-full w-full"/>
                        </div>
                    </div>
                    {/* THIS IS THE DESCRIPTION DIV */}
                    <div className="flex h-1/2 items-center mx-5">
                        <div>
                             <h1 className={`${libreBaskerville.className}  itemName p-2`}>
                            {cartItem.itemInformation.name}
                            </h1>
                            <p className={`${libreBaskerville.className}  itemDescription p-2`}>
                                {cartItem.itemInformation.description}
                            </p>
                            <p className={`${libreBaskerville.className}  itemPrice p-2`}>
                                <strong>{cartItem.itemInformation.price}</strong>
                            </p>
                            <p>
                                <strong>{quantity}</strong>
                            </p>
                        </div>
                    </div>
                </div>
    )
}