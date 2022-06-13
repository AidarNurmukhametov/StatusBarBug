namespace StatusBarBug;

public partial class MainPage : ContentPage
{
	bool isLightTheme = true;

	public MainPage() {
		InitializeComponent();
	}

	void OnCounterClicked(object sender, EventArgs e) {
		isLightTheme = !isLightTheme;
        if (sender is BindableObject bindableObject) {
			bindableObject.Dispatcher.Dispatch(() => ChangeStatusBar(isLightTheme));
        }
	}

    static void ChangeStatusBar(bool isLightTheme) {
#if IOS
		UIKit.UIApplication.SharedApplication.SetStatusBarStyle(isLightTheme ? UIKit.UIStatusBarStyle.DarkContent : UIKit.UIStatusBarStyle.LightContent, false);
		UIKit.UIWindow window = UIKit.UIApplication.SharedApplication.KeyWindow;
		UIKit.UIViewController viewController = window.RootViewController;
		while (viewController.PresentedViewController != null)
			viewController = viewController.PresentedViewController;
		viewController.SetNeedsStatusBarAppearanceUpdate();
#endif
	}
}

