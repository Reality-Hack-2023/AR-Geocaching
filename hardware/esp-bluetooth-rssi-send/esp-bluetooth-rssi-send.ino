/* References: */
// "How to use esp_bt_gap_read_rssi_delta function to get bluetooth classic RSSI from ESP32?" - Stack Overflow
//   https://stackoverflow.com/questions/52572703/how-to-use-esp-bt-gap-read-rssi-delta-function-to-get-bluetooth-classic-rssi-fro


#include "esp_gap_bt_api.h"
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;

byte addr[6] = { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

void callback(esp_spp_cb_event_t event, esp_spp_cb_param_t *param) {
  // https://techtutorialsx.com/2018/12/11/esp32-arduino-serial-over-bluetooth-get-client-address/
  if (event == ESP_SPP_SRV_OPEN_EVT) {
    for (int i = 0; i < 6; i++) {
      addr[i] = param->srv_open.rem_bda[i];
    }
  }
}

void (*p[2])(esp_spp_cb_event_t, esp_spp_cb_param_t*) = { &callback, NULL };

void setup() {
  SerialBT.register_callback(p);
  SerialBT.begin("geocache");
  esp_bt_gap_register_callback(gap_callback);
  pinMode(2, OUTPUT);
}

bool i = 0;

void loop() {
  delay(10);
  if (SerialBT.hasClient()) {
    SerialBT.print("sending data to ");
    for(int i = 0; i < 6; ++i)
      SerialBT.printf("%02X-", addr[i]);
    SerialBT.println("");
    esp_bt_gap_read_rssi_delta(addr);
    delay(100);
  }
  if (i) {
    digitalWrite(2, HIGH);
    i = !i;
  } else {
    digitalWrite(2, LOW);
    i = !i;
  }
}

void gap_callback(esp_bt_gap_cb_event_t event, esp_bt_gap_cb_param_t *param) {
  if (event == ESP_BT_GAP_READ_RSSI_DELTA_EVT) {
    SerialBT.print("rssi: ");
    SerialBT.println(param->read_rssi_delta.rssi_delta);
  }
}