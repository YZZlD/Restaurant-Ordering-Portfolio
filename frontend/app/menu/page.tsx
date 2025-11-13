'use client'

import MenuItemCard from "@/components/menuItemCard";
import { useState } from "react";
import { menuItems, updateMenuItems } from "../src/APIHandling";

export default function Page()
{
    const [loading, setLoading] = useState(true);

    async function getMenuItems(): Promise<object[]>{
        try{
            const res = await fetch('localhost:5223/api/menuItems');
            if(!res.ok) throw new Error(`${res.status}`);

            const menuItems = await res.json();
            return menuItems;
        } catch(err)
        {
            console.log(err)
        } finally{
            setLoading(false);
        }
        return [];
    }

    if(menuItems.length == 0)
    {
        getMenuItems().then(result => {
            updateMenuItems(result);
        })
    }
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
    if (menuItems.length == 0) return <p className="text-black">ERROR LOADING MENU</p>


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
