
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace NumberGame
{
    [Activity(Label = "Activity")]
    public class GameActivity: Activity {

        Button leftButton, rightButton;
        TextView scoreTextView, messageTextView;
        int score;

        protected override void OnCreate(Bundle savedInstanceState) {

            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Game);

			leftButton = FindViewById<Button>(Resource.Id.LeftButton);
            rightButton = FindViewById<Button>(Resource.Id.RightButton);
            scoreTextView = FindViewById<TextView>(Resource.Id.gameScoreTextView);
			messageTextView = FindViewById<TextView>(Resource.Id.gameMessageTextView);
			messageTextView.Text = "Choose the bigger number!";

			SetButtonValues();

			leftButton.Click += (sender, e) => {
                SetScoreAndMessage(LeftNumberIsBigger());
				SetButtonValues();
			};

            rightButton.Click += (sender, e) => {
                SetScoreAndMessage(RightNumberIsBigger());
				SetButtonValues();
			};
		}

        private Boolean LeftNumberIsBigger() {
            return Int32.Parse(leftButton.Text) > Int32.Parse(rightButton.Text);
        }

        private Boolean RightNumberIsBigger() {
            return !LeftNumberIsBigger(); 
        }


        private void SetScoreAndMessage(Boolean isRightAnswer) {
            scoreTextView.Text = score.ToString();
            if (isRightAnswer) {
                score += 10;
                messageTextView.Text = "Congrats, you make it!";
                messageTextView.SetTextColor(Color.Green);
            }
            else  {
                score -= 10;
                messageTextView.Text = "Oops, try again!";
				messageTextView.SetTextColor(Color.Red);
			}
			scoreTextView.SetTextColor(score < 0 ? Color.Red : Color.Green);
			scoreTextView.Text = score.ToString();
		}

        private void SetButtonValues() {
            int left = 0, right = 0;
            while (left == right) {
				left = GenerateNumber();
				right = GenerateNumber();
			}
            leftButton.Text = left.ToString();
            rightButton.Text = right.ToString();
		}

        private int GenerateNumber() {
            Random rnd = new Random();
            return rnd.Next(1000);
        }
    }
}