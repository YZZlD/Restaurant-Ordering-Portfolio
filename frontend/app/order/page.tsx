'use client'

import { useState } from "react";
import getMenuItems from "../src/APIHandling";
import OrderItemCard from "@/components/orderItemCard";

export default function Page()
{
    const [loading, setLoading] = useState(true);
    const [cart, setCart] = useState<object[]>([]);

    const addMenuItemToCart = (id:number) => {
        setCart([...cart, menuItems[id]]);
    }

    const removeMenuItemFromCart = (id:number) => {
        setCart(cart.filter((item:any) => {
            item.id !== id;
        }))
    }

    let menuItems: object[] = [];

    getMenuItems().then((result) => {
        setLoading(false);
        menuItems = result;
    })

    const newMenuItems = [
        {id: 1, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 2, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 3, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 4, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 5, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 6, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'}
    ]

    return (
        <div className="grid grid-cols-1 gap-x-4 gap-y-10 m-10">
            {newMenuItems.map(item => (
                <div key={item.id} className="">
                    <OrderItemCard onAdd={() => addMenuItemToCart(item.id)} onRemove={() => removeMenuItemFromCart(item.id)} menuItem={item}/>
                </div>
            ))}
        </div>
    )
}
