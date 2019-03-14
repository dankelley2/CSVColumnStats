using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    internal class CSVTreeView : TreeView
    {
        private XmlDocument xmlDoc;

        public CSVTreeView(XmlDocument xmlDoc)
        {
            this.xmlDoc = xmlDoc;
            this.Dock = DockStyle.Fill;
            LoadTreeViewFromXmlDoc();
        }

        /// <summary>
        /// Load Tree View from our XML Document Reference
        /// </summary>
        private void LoadTreeViewFromXmlDoc()
        {
            // Add the root node's children to the TreeView.
            this.Nodes.Clear();

            // Make the Parent Tree View Node.
            TreeNode rootNode = this.Nodes.Add(xmlDoc.DocumentElement.Name);
            rootNode.BackColor = Color.LightBlue;

            AddTreeViewChildNodes(rootNode, xmlDoc.DocumentElement);
        }

        // Add the children of this XML node 
        // to this child nodes collection.
        private void AddTreeViewChildNodes(TreeNode treeParent, XmlNode xmlParent)
        {
            //Add DTS Parent Section
            TreeNodeCollection treeParent_nodes = treeParent.Nodes;

            //Find XPath
            string xpath = xmlTools.FindXPath(xmlParent);
            if (xpath != "")
            {
                treeParent.Tag = xpath;

                //If Attributes exist for current node
                if (xmlParent.Attributes != null)
                {
                    foreach (XmlAttribute xmlAttribute in xmlParent.Attributes)
                    {
                        //Add to TreeView
                        TreeNode AttrNode = treeParent_nodes.Add(xmlAttribute.Name + ": " + xmlAttribute.Value);
                        AttrNode.BackColor = Color.LightGoldenrodYellow;

                        //Find XPath
                        string attrxpath = xmlTools.FindXPath(xmlAttribute);
                    }
                }
            }


            foreach (XmlNode child_node in xmlParent.ChildNodes)
            {
                TreeNode new_node;
                // Make the new TreeView node.
                if (child_node.Name == "#text")
                {
                    new_node = treeParent_nodes.Add(child_node.Value);
                }
                else
                {
                    new_node = treeParent_nodes.Add(child_node.Name);
                }

                // Recursively make this node's descendants.
                AddTreeViewChildNodes(new_node, child_node);

                // If this is a leaf node, make sure it's visible.
                if (new_node.Nodes.Count == 0)
                {
                    //new_node.EnsureVisible();
                    new_node.BackColor = Color.LightGreen;
                }
                else
                {
                    new_node.BackColor = Color.LightBlue;
                }

            }
        }


    }
}