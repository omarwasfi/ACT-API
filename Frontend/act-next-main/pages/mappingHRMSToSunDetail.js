import React, { useEffect, useRef, useState } from "react";
import Head from "next/head";
import axios from "axios";
import useInput from "../components/hooks/useInput";

import Header from "../components/header/header.js";
import SideNav from "../components/sideNav/sideNav";
import BreadCrumb from "../components/breadCrumb/breadCrumb";

import Trash from "../public/images/trash.svg";
import Edit from "../public/images/edit.svg";
import Loader from "../public/images/loader.gif";

import { apiPath } from "../components/apiPath/apiPath";

const mappingHRMSToSunDetail = () => {
  const [loading, setLoading] = useState(false);
  const {
    value: sunAttribute,
    resetValue: resetSunAttribute,
    setValue: setSunAttribute,
    bind: bindSunAttribute,
  } = useInput("");

  const {
    value: valueOfType,
    resetValue: resetValueOfType,
    setValue: setValueOfType,
    bind: bindValueOfType,
  } = useInput("");

  const [columns, setColumns] = useState([]);

  const types = ["DateTime", "Decimal", "Double", "Int", "String", "Short"];

  const [type, setType] = useState("DateTime");
  const [mapWithOperaName, setMapWithOperaName] = useState("");
  const [mapWithOperaNames, setMapWithOperaNames] = useState([]);
  const [conditionForType, setConditionForType] = useState("dateTimeValue");

  useEffect(() => {
    axios
      .get(`${apiPath}Mapping/HrmsToSun/ReportToDetail/GetHrmsReportSunDETAIL`)
      .then((res) => {
        setColumns(res.data);
        console.log(res.data);
      });

    axios.get(`${apiPath}Hrms/Report/GetColumns`).then((res) => {
      setMapWithOperaNames(res.data.map((name) => name.name));
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    if (condition === "isConst") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          [conditionForType]: valueOfType,
          isConst: true,
          autoGenerated: false,
        },
      ]);
    } else if (condition === "isAuto") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          isConst: false,
          autoGenerated: true,
        },
      ]);
    } else if (condition === "mapWithOpera") {
      setColumns([
        ...columns,
        {
          sunAttribute: sunAttribute,
          valueType: type,
          mapWithHRMS: mapWithOperaName,
          isConst: false,
          autoGenerated: false,
        },
      ]);
    }
    setSunAttribute("");
    setType("");
    setValueOfType("");
  };

  const [nunberOrString, setNumberOrString] = useState(true);

  useEffect(() => {
    if (type === "DateTime") {
      setConditionForType("dateTimeValue");
    } else if (type === "Decimal") {
      setConditionForType("decimalValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Double") {
      setConditionForType("doubleValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Int") {
      setConditionForType("intValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "Short") {
      setConditionForType("shortValue");
      if (valueOfType) setValueOfType(parseInt(valueOfType));
    } else if (type === "String") {
      setConditionForType("stringValue");
    }
    if (type === "DateTime" || type === "String") {
      setNumberOrString(false);
    } else if (
      type === "Decimal" ||
      type === "Double" ||
      type === "Int" ||
      type === "Short"
    ) {
      setNumberOrString(true);
    }
  }, [type, valueOfType]);

  const isFirstRender = useRef(true);

  useEffect(() => {
    if (!isFirstRender.current) {
      // do something after state has updated
      if (columns.length > 0) {
        const columnsConfig = {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          data: [...columns],
        };
        axios(
          `${apiPath}Mapping/HrmsToSun/ReportToDetail/UpdateHrmsReportSunDETAIL`,
          columnsConfig
        )
          .then((res) => {
            console.log(res);
            console.log(columns);
          })
          .catch((error) => {
            console.error("There was an error!", error);
          });
      } else {
        alert("Error!");
      }
    }
  }, [columns]);

  useEffect(() => {
    isFirstRender.current = false; // toggle flag after first render/mounting
  }, []);

  const [isEdited, setIsEdited] = useState(false);

  const [idOfeditedColumn, setIdOfEditedColumn] = useState("");

  const handleEdit = (sunAttribute, valueType, i) => {
    setIsEdited(true);
    setType(valueType.charAt(0).toUpperCase() + valueType.slice(1));
    setSunAttribute(sunAttribute);
    setIdOfEditedColumn(sunAttribute);
  };

  const handleUpdate = (e) => {
    e.preventDefault();
    setColumns(
      columns.map((column) => {
        if (column.sunAttribute !== idOfeditedColumn) return column;
        else {
          if (condition === "isConst") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              [conditionForType]: valueOfType,
              isConst: true,
              autoGenerated: false,
            };
          } else if (condition === "isAuto") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              isConst: false,
              autoGenerated: true,
            };
          } else if (condition === "mapWithOpera") {
            return {
              ...columns,
              sunAttribute: sunAttribute,
              valueType: type,
              mapWithHRMS: mapWithOperaName,
              isConst: false,
              autoGenerated: false,
            };
          }
        }
      })
    );
    setIsEdited(false);
    setSunAttribute("");
    setType("");
    setValueOfType("");
  };

  const handleDelete = (sunAttribute) => {
    if (columns.length > 0) {
      const newColumns = columns.filter(
        (item) => item.sunAttribute !== sunAttribute
      );
      setColumns([...newColumns]);
    }
  };

  const [condition, setCondition] = useState("");

  const handleCondition = (e) => {
    setCondition(e.target.value);
  };

  const handleLoadDefaults = (e) => {
    e.preventDefault();
    setLoading(true);
    axios
      .post(`${apiPath}Mapping/HrmsToSun/ReportToDetail/LoadDefaults`)
      .then((res) => {
        if (res.status === 200) {
          console.log("load defaults is done");
          setLoading(false);
        }
      })
      .catch((error) => {
        console.error("There was an error!", error.response.data);
      });
  };

  return (
    <div>
      <Head>
        <title>Mapping HRMS To Sun Detail</title>
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
              <h5>Mapping HRMS Configraution</h5>
              <span type="button" onClick={handleLoadDefaults}>
                Load Defaults
              </span>
            </div>

            <BreadCrumb
              path="mappingHRMSToSunDetail"
              page="Mapping Opera Configraution"
            />
          </div>

          <div className={`main_sun_body scrollable ${loading && "loading"}`}>
            <div className="container">
              <form
                onSubmit={isEdited ? handleUpdate : handleSubmit}
                className="multi-inputs more"
                style={{ marginTop: "30px" }}
              >
                <h5>Add new Column</h5>
                <div>
                  <div>
                    <label>Sun Attribute</label>
                    <input type="text" {...bindSunAttribute} required />
                  </div>
                  <div className="select-with-label">
                    <label>Choose a Type</label>
                    <select
                      name="columns"
                      id="columns"
                      required
                      value={type}
                      onChange={(e) => setType(e.target.value)}
                    >
                      {types.map((type, i) => (
                        <option key={i} value={type}>
                          {type}
                        </option>
                      ))}
                    </select>
                  </div>
                  <div className="radio-buttons">
                    <div>
                      <span>Choose</span>
                      <input
                        type="radio"
                        id="isConst"
                        name="condition"
                        required
                        onChange={(e) => handleCondition(e)}
                        value="isConst"
                      />
                      <label htmlFor="isConst">isConst</label>
                    </div>

                    <div>
                      <input
                        type="radio"
                        id="isAuto"
                        name="condition"
                        required
                        onChange={(e) => handleCondition(e)}
                        value="isAuto"
                      />
                      <label htmlFor="isAuto">isAuto</label>
                    </div>
                    <div>
                      <input
                        type="radio"
                        id="mapWithOpera"
                        name="condition"
                        required
                        onChange={(e) => handleCondition(e)}
                        value="mapWithOpera"
                      />
                      <label htmlFor="mapWithOpera">mapWithHRMS</label>
                    </div>
                  </div>
                  <div>
                    {condition === "isConst" && (
                      <>
                        <label>Value</label>
                        <input
                          type={nunberOrString ? "number" : "text"}
                          {...bindValueOfType}
                          required
                        />
                      </>
                    )}
                    {condition === "isAuto" && null}
                    {condition === "mapWithOpera" && (
                      <select
                        name="mapWithOperaName"
                        id="mapWithOperaName"
                        required
                        value={mapWithOperaName}
                        onChange={(e) => setMapWithOperaName(e.target.value)}
                      >
                        {mapWithOperaNames.map((mapWithOperaName, i) => (
                          <option key={i} value={mapWithOperaName}>
                            {mapWithOperaName}
                          </option>
                        ))}
                      </select>
                    )}
                  </div>

                  <div>
                    {isEdited ? (
                      <button type="submit">Update Column</button>
                    ) : (
                      <button type="submit">Submit</button>
                    )}
                  </div>
                </div>
              </form>

              <div className="table">
                <table>
                  <tbody>
                    <tr>
                      <th>Sun Attribute</th>
                      <th>Value Type</th>
                      <th>State</th>
                      <th>Value</th>
                      {/* <th>Auto Generated</th>
                      <th>Is Const</th>
                      <th>Map With OPERA</th> */}
                      <th>Settings</th>
                    </tr>
                  </tbody>
                  <tbody>
                    {columns.map(
                      (
                        {
                          sunAttribute,
                          valueType,
                          id,
                          autoGenerated,
                          isConst,
                          mapWithHRMS,
                          stringValue,
                          intValue,
                          shortValue,
                          dateTimeValue,
                          decimalValue,
                          doubleValue,
                        },
                        i
                      ) => (
                        <tr key={i}>
                          <td>{sunAttribute}</td>
                          <td>{valueType}</td>
                          <td>
                            {(autoGenerated && "Auto generated") ||
                              (isConst && "Is const") ||
                              (mapWithHRMS && "Map with HRMS")}
                          </td>
                          <td>
                            {(intValue || intValue === 0) && intValue}
                            {(shortValue || shortValue === 0) && shortValue}
                            {(decimalValue || decimalValue === 0) &&
                              decimalValue}
                            {(doubleValue || doubleValue === 0) && doubleValue}
                            {stringValue?.length > 0 && stringValue}
                            {dateTimeValue?.length > 0 && shortValue}
                            {mapWithHRMS && mapWithHRMS}
                          </td>
                          {/* <td>{autoGenerated ? "true" : "false"}</td>
                          <td>{isConst ? "true" : "false"}</td>
                          <td>{mapWithHRMS && mapWithHRMS}</td> */}
                          <td>
                            <img
                              src={Trash}
                              alt="Delete"
                              onClick={() => handleDelete(sunAttribute)}
                            />

                            <img
                              src={Edit}
                              alt="Edit"
                              onClick={() =>
                                handleEdit(sunAttribute, valueType, i)
                              }
                            />
                          </td>
                        </tr>
                      )
                    )}
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </main>
    </div>
  );
};
export default mappingHRMSToSunDetail;
