'use client'

import MenuItemCard from "@/components/menuItemCard";
import { useState } from "react";
import getMenuItems from "../src/APIHandling";

export default function Page()
{
    const [loading, setLoading] = useState(true);

    let menuItems: object[] = [];

    getMenuItems().then((result) => {
        setLoading(false);
        menuItems = result;
    })

    //THIS IS TEST BEFORE I HOOK UP AND FIX THE API
    const newMenuItems = [
        {id: 1, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 2, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 3, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 4, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 5, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'},
        {id: 6, name: 'Standard Burger', src: '/burger-background.jpg', price: '$10.99', description: 'Canadian beef with onions and our signature sauce'}
    ]

    if (loading) return <p>Loading...</p>
    // if (menuItems.length == 0) return <p className="text-black">ERROR LOADING MENU</p>


    return (
        <div className="grid grid-cols-1 gap-x-4 gap-y-10 m-10 lg:grid-cols-2 xl:grid-cols-3">
            {newMenuItems.map(item => (
                <div key={item.id} className="flex justify-center">
                    <MenuItemCard menuItem={item}/>
                </div>
            ))}
        </div>

    )
}
