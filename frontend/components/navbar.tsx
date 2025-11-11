import { robotoBold } from "@/app/ui/fonts"

export default function Navbar()
{
    return(
        <nav>
            <div className="border border-white-800 flex h-20 ">
                <div className="border border-red-800 w-1/4">

                </div>
                <div className="border border-blue-800 w-1/2 flex justify-between px-20 items-center">
                    <a href="/about" className={`${robotoBold.className} navlink `}>About</a>
                    <a href="/menu" className={`${robotoBold.className} navlink`}>Menu</a>
                    <a href="/contact-us" className={`${robotoBold.className} navlink`}>Contact Us</a>
                    <a href="/order" className={`${robotoBold.className} navlink`}>Order Now</a>
                </div>
                <div className="border border-green-800 w-1/4">
                </div>
            </div>


        </nav>
    )
}
