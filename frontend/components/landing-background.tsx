import Image from "next/image"

export default function LandingBackground()
{
    return (
        <div className="w=full h=50%">
            <Image alt="burger meal" fill={true} src="/burger-background.jpg" className="object-cover relative z-0"/>
        </div>
    )
}
