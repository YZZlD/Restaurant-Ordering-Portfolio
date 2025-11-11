import { robotoBold, condimentTitle } from "@/app/ui/fonts"
import Image from "next/image";

export default function Navbar()
{
    return(
            <nav className="my-5 mx-5 px-10 h-1/6 bg-red-700 rounded-md">
                <div className="flex h-full">
                    <div className=" w-1/8 flex items-center overflow-hidden relative" >
                        <Image alt="restaurant logo" fill={true} src="../day82-burger.svg" className="" priority={true}/>
                    </div>
                    <div className=" w-1/5 flex items-center justify-start px-10">
                        <a href="/" className={`${condimentTitle.className}  restaurantTitle`}>Burger Bites</a>
                    </div>
                    <div className=" w-1/2 flex justify-between px-20 items-center">
                        <a href="/about" className={`${robotoBold.className} navlink `}>About</a>
                        <a href="/menu" className={`${robotoBold.className} navlink`}>Menu</a>
                        <a href="/contact-us" className={`${robotoBold.className} navlink`}>Contact Us</a>
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
