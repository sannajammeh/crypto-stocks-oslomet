// import { useStocks } from "./hooks";

import CoinDisplay from "./CoinDisplay";
import OrderHistory from "./OrderHistory";
import Sidebar from "./sidebar/Sidebar";

const DashboardPage = () => {
    return (
        <div className="dashboard">
            <Sidebar />
            <aside className="right-sidebar"></aside>
            <CoinDisplay />
            <OrderHistory />
        </div>
    );
};

export default DashboardPage;
