import React, { useEffect, useState } from "react";
import Head from "next/head";
import axios from "axios";
import useInput from "../components/hooks/useInput";
import { useRouter } from "next/router";

import Header from "../components/header/header.js";
import SideNav from "../components/sideNav/sideNav";
import BreadCrumb from "../components/breadCrumb/breadCrumb";

import Checked from "../public/images/checked.svg";
import NotChecked from "../public/images/notChecked.svg";
import Loader from "../public/images/loader.gif";

import Link from "next/link";

import { apiPath } from "../components/apiPath/apiPath";

const HRMSConfig = () => {
  const router = useRouter();

  // const [disable, setDisable] = useState(true);
  const [loading, setLoading] = useState(false);

  const {
    value: day,
    resetValue: resetDay,
    setValue: setDay,
    bind: bindDay,
  } = useInput("");

  const {
    value: hour,
    resetValue: resetHour,
    setValue: setHour,
    bind: bindHour,
  } = useInput("");

  const {
    value: minute,
    resetValue: resetMinute,
    setValue: setMinute,
    bind: bindMinute,
  } = useInput("");

  const {
    value: connectionString,
    resetValue: resetConnectionString,
    setValue: setConnectionString,
    bind: bindConnectionString,
  } = useInput("");

  useEffect(() => {
    axios.get(`${apiPath}Hrms/GetConnectionString`).then((res) => {
      setConnectionString(res.data);
    });

    axios.get(`${apiPath}Hrms/GetCycleTime`).then((res) => {
      setDay(res.data.day);
      setHour(res.data.hour);
      setMinute(res.data.min);
    });
  }, []);

  // useEffect(() => {
  //   console.log(hour.length);
  //   if (day || hour || minute || connectionString) {
  //     setDisable(false);
  //   } else if (!day || !hour || !minute || !connectionString) {
  //     setDisable(true);
  //   }
  // }, [day, hour, minute, connectionString]);

  const handleConfig = (e) => {
    e.preventDefault();
    setLoading(true);
    axios
      .post(
        `${apiPath}Hrms/UpdateConnectionString?ConnectionString=${connectionString}`
      )
      .then((res) => console.log(res))
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });

    const cycleTimeConfig = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      data: { day: parseInt(day), hour: parseInt(hour), min: parseInt(minute) },
    };

    axios(`${apiPath}Hrms/UpdateCycleTime`, cycleTimeConfig)
      .then((res) => {
        if (res.status === 200) {
          console.log("config cycle time is done");
          axios(`${apiPath}Shutdown/blow-me-up`)
            .then((res) => {
              if (res.status === 200) {
                console.log("shut down is done");
                setLoading(false);
              }
            })
            .catch((error) => {
              console.error("There was an error!", error);
            });
        }
      })
      .catch((error) => {
        console.error("There was an error!", error);
      });
    router.push({
      pathname: `/hrmsReportConfig`,
    });
  };

  const handleLoadDefaults = (e) => {
    e.preventDefault();
    setLoading(true);
    axios
      .post(`${apiPath}Hrms/LoadDefaults`)
      .then((res) => {
        if (res.status === 200) {
          console.log("load defaults is done");
          axios(`${apiPath}Shutdown/blow-me-up`)
            .then((res) => {
              if (res.status === 200) {
                console.log("shut down is done");
                setLoading(false);
              }
            })
            .catch((error) => {
              console.error("There was an error!", error);
            });
        }
      })
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
  };

  return (
    <div>
      <Head>
        <title>HRMS Config</title>
      </Head>

      <Header />
      <SideNav />
      {loading && (
        <div className="loader">
          <img src={Loader} alt="loader" />
        </div>
      )}
      <main className="main-sun-config">
        <div className="container">
          <div className="main_sun_head">
            <div className="head">
              <h5>HRMS Configraution</h5>
              <span type="button" onClick={handleLoadDefaults}>
                Load Defaults
              </span>
            </div>
            <BreadCrumb path="hrmsConfig" page="HRMS Configraution" />
          </div>
          <div className={`main_sun_body ${loading && "loading"}`}>
            <div className="container">
              <div className="links">
                <div className="active">
                  <Link href="/hrmsConfig">
                    <a>
                      <img src={Checked} alt="Checked" />

                      <span>Configration</span>
                    </a>
                  </Link>
                </div>
                <div>
                  <Link href="/hrmsReportConfig">
                    <a>
                      <img src={NotChecked} alt="NotChecked" />
                      <span>HRMS Report Configration</span>
                    </a>
                  </Link>
                </div>
              </div>

              <form onSubmit={handleConfig} className="multi-inputs">
                <h5>Monthly at</h5>
                <div>
                  <div>
                    <label>Day</label>
                    <input
                      type="number"
                      required
                      min="0"
                      max="28"
                      {...bindDay}
                    />
                  </div>
                  <div>
                    <label>Hour</label>
                    <input
                      type="number"
                      required
                      min="0"
                      max="23"
                      {...bindHour}
                    />
                  </div>
                  <div>
                    <label>Minute</label>
                    <input
                      type="number"
                      required
                      min="0"
                      max="59"
                      {...bindMinute}
                    />
                  </div>

                  <div>
                    <label>Connection</label>
                    <input type="text" required {...bindConnectionString} />
                    <button type="submit">Config</button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};
export default HRMSConfig;
