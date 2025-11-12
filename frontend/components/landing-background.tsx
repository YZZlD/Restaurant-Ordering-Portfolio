import Image from "next/image"

export default function LandingBackground()
{
    return (
        <div className="fixed top-0 right-0 w-full h-full">
            <Image alt="burger meal" fill={true} src="/burger-background.jpg" className="h-full w-full object-cover z-0"/>
        </div>
    )
}
