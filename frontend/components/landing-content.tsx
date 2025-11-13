import Image from "next/image"
import { lobster } from "@/app/ui/fonts"

export default function LandingContent()
{
    return (
        <div className="relative z-1 flex justify-center my-20">
            <div className="relative flex flex-wrap justify-center text-center w-1/3 space-y-15">
                <h1 className={`${lobster.className} dropshadow header`}>Welcome to Burger Bites</h1>
                <h2 className={`${lobster.className} dropshadow sub-header`}>Dine in | Take out | Delivery</h2>
                <p className={`${lobster.className} dropshadow main-text text-center`}>
                    At Burger Bites we believe in fast, affordable food that tastes great.
                    Our mission is to bring joy and community with every bite. Since 1910
                    we've been bringing smiles to faces of all ages and backgrounds. From
                    our juicy burgers to our crisp fries we know there is something for you!
                </p>
                <div className="h-50 w-50 rounded-full border-4 border-black overflow-hidden flex items-center">
                    <img alt="restaurant logo" src="../day82-burger.svg" className="w-auto h-full"/>
                </div>
            </div>
        </div>
    )
}
