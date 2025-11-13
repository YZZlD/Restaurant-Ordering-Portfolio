'use client'

import { libreBaskerville } from "@/app/ui/fonts"
import { useState } from "react"

export default function CartItemCard({cartItem}: {cartItem:any}){

    const [quantity, setQuantity] = useState(1);

    return (
        <div className="relative grid grid-cols-10 w-full h-50 rounded-md border-4 border-black bg-red-200">
            <div className="relative col-start-1 col-span-3 w-full h-full rounded-md border-4 border-red-900">
                <div className="relative w-full h-full border-4 border-black">
                    <img alt={cartItem.name} src={cartItem.src} className="object-cover h-full w-full"/>
                </div>
            </div>
            <div className="relative w-full h-full col-start-4 col-span-4">
                <h1 className={`${libreBaskerville.className}  itemName p-2 text-black`}>
                {cartItem.name}
                </h1>
                <p className={`${libreBaskerville.className}  itemDescription p-2 text-black`}>
                    {cartItem.description}
                </p>
                <p className={`${libreBaskerville.className}  itemPrice p-2 text-black`}>
                    <strong>{cartItem.price}</strong>
                </p>
            </div>
        </div>
    )
}