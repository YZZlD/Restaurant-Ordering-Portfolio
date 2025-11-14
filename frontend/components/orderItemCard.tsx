'use client'

import { libreBaskerville } from "@/app/ui/fonts"
import { useState } from "react"

export default function OrderItemCard({onAdd, onRemove, menuItem, inCart, setItemInCart} : {menuItem:any, onAdd:Function, onRemove:Function, inCart:boolean, setItemInCart:Function})
{
    return (
        <div className="relative grid grid-cols-10 w-full h-50 rounded-md border-4 border-black bg-red-200">
            <div className="relative col-start-1 col-span-3 w-full h-full rounded-md border-4 border-red-900">
                <div className="relative w-full h-full border-4 border-black">
                    <img alt={menuItem.name} src={menuItem.src} className="object-cover h-full w-full"/>
                </div>
            </div>
            <div className="relative w-full h-full col-start-4 col-span-4">
                <h1 className={`${libreBaskerville.className}  itemName p-2 text-black`}>
                {menuItem.name}
                </h1>
                <p className={`${libreBaskerville.className}  itemDescription p-2 text-black`}>
                    {menuItem.description}
                </p>
                <p className={`${libreBaskerville.className}  itemPrice p-2 text-black`}>
                    <strong>${menuItem.price}</strong>
                </p>
            </div>
            <div className="flex items-center justify-center col-start-8 col-span-3">
                {inCart ? <button onClick={() => {onRemove(); setItemInCart()}} className="bg-white hover:bg-gray-300 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow">Remove From Order</button> :
                <button onClick={() => {onAdd(); setItemInCart()}} className="bg-white hover:bg-gray-300 text-gray-800 font-semibold py-2 px-4 border border-gray-400 rounded shadow">Add To Order</button>}
            </div>
        </div>
    )
}
