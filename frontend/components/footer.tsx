export default function Footer()
{
    return (
        <div className="relative h-1/3 w-full">
            <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"></link>
            <div className="flex justify-center space-x-10 p-10 bg-[#ac0000]">
                <div className="grid-row-4 space-y-5">
                    <h1>Address</h1>
                    <p>Dine In, Take-out, and Delivery</p>
                    <p>Unit 4 — 123 Example Street<br></br>Exampleville, ON A1A 1A1<br></br>Canada</p>
                </div>
                <div className="space-y-5">
                    <h1>Opening Hours</h1>
                    <div>
                        <p>Monday: 11:30 a.m. - 9:00 p.m.</p>
                        <p>Tuesday: 11:30 a.m. - 9:00 p.m.</p>
                        <p>Wednesday: 11:30 a.m. - 9:00 p.m.</p>
                        <p>Thursday: 11:30 a.m. - 9:00 p.m.</p>
                        <p>Friday: 11:30 a.m. - 10:00 p.m.</p>
                        <p>Saturday: 10:00 a.m. - 10:00 p.m.</p>
                        <p>Sunday: 10:00 a.m. - 8:00 p.m.</p>
                    </div>
                </div>
                <div className="space-y-5">
                    <h1>Contact Us</h1>
                    <p>[Phone Number Goes Here]</p>
                    <a href="#" className="fa fa-twitter social-button"></a>
                    <a href="#" className="fa fa-instagram social-button"></a>
                </div>
            </div>
            <div className="grid grid-row-2 space-y-10 p-10 bg-[#dd2d2d]">
                <div className="flex justify-center space-x-20">
                    <a href="#">Terms of Use</a>
                    <a href="#">Privacy Policy</a>
                </div>
                <div className="flex justify-center">
                    <p>Copyright © 2025 Burger Bites - All Rights Reserved.</p>
                </div>
            </div>
        </div>

    )
}
