'use client'

import { useState, useEffect } from "react";
import getMenuItems from "../src/APIHandling";
import OrderItemCard from "@/components/orderItemCard";
import OrderCart from "@/components/orderCart";

export default function Page()
{
    const [loading, setLoading] = useState(true);
    const [cart, setCart] = useState<any[]>([]);

    let menuItems: any[] = [];

    // getMenuItems().then((result) => {
    //     setLoading(false);
    //     menuItems = result;
    // })

    const addMenuItemToCart = (id:number) => {
        setCart([...cart, newMenuItems.filter((item:any) => item.id === id)[0]]);
        console.log(cart);
    }
    

    const removeMenuItemFromCart = (id:number) => {
        setCart(cart.filter((item:any) => item.id !== id));
    }

    const newMenuItems = [
        {id: 1, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 2, name: 'Deluxe Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 3, name: 'Super Deluxe Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 4, name: 'Mini Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 5, name: 'Special Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 6, name: 'Not A Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'}
    ]

    // if (loading) return <p>Loadingl...</p>;

    return (
        <div className="relative grid grid-cols-10 gap-x-4">
            <div className="relative grid grid-cols-1 col-start-1 col-span-6 gap-x-4 gap-y-10 m-10">
                {newMenuItems.map(item => (
                    <div key={item.id} className="">
                        <OrderItemCard onAdd={() => addMenuItemToCart(item.id)} onRemove={() => removeMenuItemFromCart(item.id)} menuItem={item}/>
                    </div>
                ))}
            </div>
            <OrderCart cart={cart}/>   
        </div>
        
    )
}
