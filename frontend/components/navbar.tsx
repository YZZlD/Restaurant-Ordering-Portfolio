'use client'

import { robotoBold, condimentTitle } from "@/app/ui/fonts"
import Image from "next/image";
import { usePathname } from "next/navigation";

// Navbar to be used for all routes on the website. Consists of the restaurant logo, restaurant name, about/menu/contactus routes, and an
// emphasized order button linking to the order route.
export default function Navbar()
{
    //We grab the pathname to conditionally modify the appearance of the current landing page.
    const pathname = usePathname();

    return(
            <nav className=" h-1/6 bg-red-700 sticky z-5">
                <div className="flex h-full">
                    <div className=" w-1/8 flex items-center overflow-hidden relative" >
                        <Image alt="restaurant logo" fill={true} src="../day82-burger.svg" className="" priority={true}/>
                    </div>
                    <div className=" w-1/5 flex items-center justify-start px-10">
                        <a href="/" className={`${condimentTitle.className}  restaurantTitle`}>Burger Bites</a>
                    </div>
                    <div className=" w-1/2 flex flex-col justify-between px-20 items-center lg:flex-row">
                        <a href="/about" className={`${robotoBold.className} navlink ${pathname == "/about" ? "currentPage" : ""}`}>About</a>
                        <a href="/menu" className={`${robotoBold.className} navlink ${pathname == "/menu" ? "currentPage" : ""}`}>Menu</a>
                        <a href="/contact-us" className={`${robotoBold.className} navlink ${pathname == "/contact-us" ? "currentPage" : ""}`}>Contact Us</a>
                    </div>
                    <div className=" w-1/4 flex justify-center items-center h-full">
                        <div className="border-4 border-black bg-white rounded-md h-1/3 w-1/2 flex justify-center items-center hover:bg-gray-300">
                            <a href="/order" className={`${robotoBold.className} orderLink`}>Order Now</a>
                        </div>

                    </div>
                </div>
            </nav>
    )
}
